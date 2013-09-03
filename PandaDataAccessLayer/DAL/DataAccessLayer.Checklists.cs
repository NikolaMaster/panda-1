using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer : DataAccessLayer<MainDbContext>
    {
        public Checklist Create(UserBase user, IEnumerable<AttribValue> attributeValues)
        {
            var checkList = Create<Checklist>(new Checklist { });
            foreach (var i in attributeValues)
                i.Checklist = checkList;
            checkList.AttrbuteValues = new List<AttribValue>(attributeValues);
            var checklistTypeCode = string.Empty;
            if (user is PromouterUser)
                checkList.ChecklistType = Constants.PromouterChecklistType;
            else if (user is EmployerUser)
                checkList.ChecklistType = Constants.CompanyChecklistType;
            checkList.User = user;
            return checkList;
        }

        public IEnumerable<Attrib> GetAttributes(Checklist checklist)
        {
            return DbContext
                .Attribs
                .Where(x => checklist.AttrbuteValues.Any(y => y.AttribId == x.Id))
                .ToList();
        }

        public double GetFillingPercentage(Checklist checklist)
        {
            var join = from av in checklist.AttrbuteValues
                       join a in DbContext.Attribs on av.AttribId equals a.Id
                       select new
                       {
                           Weight = a.Weight,
                           Value = av.Value != null
                       };

            return join.Sum(x => x.Value ? x.Weight : 0) * 100 / join.Sum(x => x.Weight);
        }

        public IEnumerable<DictValue> GetRangeByAttribTypeId(Guid attribTypeId)
        {
            var dictGroup = GetById<AttribType>(attribTypeId);
            if (dictGroup.Type != typeof(DictValue).FullName)
            {
                throw new Exception("Not dictionary attribute");
            }
            return dictGroup.DictGroup.DictValues.ToList();
        }

        public IEnumerable<Attrib> GetAllAttributes()
        {
            return DbContext.Attribs.ToList();
        }

        public IEnumerable<Attrib> GetAttributes(Guid checklistTypeId)
        {
            return DbContext.Attribs.Where(x => DbContext.Attrib2ChecklistType.Any(y => y.ChecklistType.Id == checklistTypeId)).ToList();
        }

        public IEnumerable<AttribValue> GetAttributeValues(Guid checklistId)
        {
            return DbContext.AttribValues.Where(x => x.ChecklistId == checklistId).ToList();
        }

        public AttribType GetAttribType(Type type)
        {
            return DbContext.AttribTypes.Single(x => x.Type == type.FullName);
        }
    }
}
