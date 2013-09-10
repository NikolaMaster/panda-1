using System.Linq;
using PandaDataAccessLayer.DAL;

namespace PandaDataAccessLayer.Entities
{
    public class EmployerUser : UserBase
    {
        public override Checklist MainChecklist
        {
            get { return Checklists.Single(x => x.ChecklistType.Code == Constants.EmployerMainChecklistTypeCode); }
        }
    }
}
