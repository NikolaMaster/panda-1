using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer.DAL;

namespace PandaDataAccessLayer.Entities
{
    public class EmployerUser : UserBase
    {
        public Checklist MainChecklist
        {
            get { return Checklists.Single(x => x.ChecklistType.Code == Constants.EmployerMainChecklistTypeCode); }
        }

        public EmployerUser()
        {
            Id = Guid.NewGuid();
        }
    }
}
