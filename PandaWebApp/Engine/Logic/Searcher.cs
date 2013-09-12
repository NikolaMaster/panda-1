using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Logic
{
    public class Searcher
    {
        public DataAccessLayer DataAccessLayer { get; protected set; }
        public Dictionary<Attrib, ComparerBase> Comparers { get; protected set; }

        public ComparerBase DefaultComparer { get; protected set; }
        public FullTextComparer FullTextComparer { get; protected set; }

        public Searcher(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
            DefaultComparer = new DynamicToPandaStringComparer(DataAccessLayer);
            Comparers = new Dictionary<Attrib, ComparerBase>()
                {
                    { DataAccessLayer.Constants.Work, new DictManyValueComparer(DataAccessLayer) },
                    { DataAccessLayer.Constants.City, new DictValueComparer(DataAccessLayer) },
                    { DataAccessLayer.Constants.Gender, new DictValueComparer(DataAccessLayer) },
                    { DataAccessLayer.Constants.Salary, new DictValueComparer(DataAccessLayer) }
                };
            FullTextComparer = new FullTextComparer(DataAccessLayer);
        }

        public IEnumerable<Checklist> Search(IEnumerable<Checklist> checklists, Dictionary<Attrib, object> values, string query)
        {
            foreach (var checklist in checklists)
            {
                var attribValues = DataAccessLayer.GetAttributeValues(checklist.Id);
                var compareResult = true;
                foreach (var value in values)
                {
                    var storedValue = attribValues.FirstOrDefault(x => x.Attrib == value.Key);
                    if (value.Value == null || (storedValue == null && value.Value == null))
                        continue;

                    var comparer = Comparers.ContainsKey(value.Key) ? Comparers[value.Key] : DefaultComparer;
                    if (!comparer.Compare(storedValue, value.Value))
                    {
                        compareResult = false;
                        break;
                    }
                }
                compareResult &= FullTextComparer.Compare(checklist, query);
                if (compareResult)
                    yield return checklist;
            }
        }
    }

    public abstract class ComparerBase
    {
        public DataAccessLayer DataAccessLayer { get; protected set; }

        private ComparerBase() { }

        public ComparerBase(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public abstract bool Compare(AttribValue storedValue, object value);
    }

    public class DynamicToPandaStringComparer : ComparerBase
    {
        public DynamicToPandaStringComparer(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override bool Compare(AttribValue storedValue, object value)
        {
            if (storedValue != null)
            {
                dynamic tmp = value;
                return storedValue.Value == tmp.ToPandaString();
            }
            else
            {
                return value != null;
            }
        }
    }

    public class DesiredWorkComparer : ComparerBase
    {
        public DesiredWorkComparer(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override bool Compare(AttribValue storedValue, object value)
        {
            var castedValue = (IEnumerable<DictValue>)value;
            if (storedValue != null)
            {
                var entityListId = Guid.Parse(storedValue.Value);
                var storedDesiredWork = DataAccessLayer.GetById<EntityList>(entityListId).DesiredWork.Select(x => x.Work);

                
                return castedValue.All(x => storedDesiredWork.Contains(x));
            }
            else 
            {
                return castedValue == null;
            }
        }
    }

    public class DictManyValueComparer : ComparerBase
    {
        public DictManyValueComparer(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override bool Compare(AttribValue storedValue, object value)
        {
            var castedValue = (IEnumerable<DictValue>)value;
            if (storedValue != null)
            {

                return castedValue.Any(x => x.Code == storedValue.Value);
            }
            else
            {
                return castedValue == null;
            }
        }
    }

    public class DictValueComparer : ComparerBase 
    {
        public DictValueComparer(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override bool Compare(AttribValue storedValue, object value)
        {
            if (storedValue != null)
            {
                return value.ToString() == storedValue.Value;
            }
            else 
            {
                return value == null;
            }
        }
    }

    public class FullTextComparer
    {
        public DataAccessLayer DataAccessLayer { get; protected set; }

        public FullTextComparer(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public bool Compare(Checklist checklist, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;
            var queryStr = value.Trim();
            var fullStr = string.Empty;
            foreach (var i in checklist.AttrbuteValues)
            {
                if (i.Value == null)
                    continue;
                var strValue = i.Value.ToString();
                if (i.Attrib.AttribType.Type == typeof(DictGroup).FullName)
                {
                    strValue = DataAccessLayer.Get<DictValue>(i.Value).Description;   
                }
                if (i.Attrib.AttribType.Type == typeof(EntityList).FullName)
                    continue;
                fullStr += strValue + " ";
            }

            if (checklist.ChecklistType == DataAccessLayer.Constants.EmployerChecklistType)
            {
                var employerNameAttrib = DataAccessLayer.GetAttributeValue(checklist.User.MainChecklist.Id, Constants.EmployerNameCode);
                fullStr += employerNameAttrib.Value;
            }
            return fullStr.Contains(queryStr);
        }
    }
}