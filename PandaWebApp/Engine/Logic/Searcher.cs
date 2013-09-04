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

        public Searcher(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
            DefaultComparer = new DynamicToPandaStringComparer(DataAccessLayer);
            Comparers = new Dictionary<Attrib, ComparerBase>()
                {
                    { DataAccessLayer.Constants.DesiredWork, new DesiredWorkComparer(DataAccessLayer) },
                };
        }

        public IEnumerable<Checklist> Search(IEnumerable<Checklist> checklists, Dictionary<Attrib, object> values)
        {
            foreach (var checklist in checklists)
            {
                var attribValues = DataAccessLayer.GetAttributeValues(checklist.Id);
                var compareResult = true;
                foreach (var value in values)
                {
                    var storedValue = attribValues.Single(x => x.Attrib == value.Key);
                    var comparer = Comparers.ContainsKey(value.Key) ? Comparers[value.Key] : DefaultComparer;
                    if (!comparer.Compare(storedValue, value.Value))
                    {
                        compareResult = false;
                        break;
                    }
                }
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
            dynamic tmp = value;
            return storedValue.Value == tmp.ToPandaString();
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
            var entityListId = Guid.Parse(storedValue.Value);
            var storedDesiredWork = DataAccessLayer.GetById<EntityList>(entityListId).DesiredWork.Select(x => x.Work);

            var castedValue = (IEnumerable<DictValue>)value;
            return castedValue.All(x => storedDesiredWork.Contains(x));
        }
    }
}