using System.Linq;

namespace PandaDataAccessLayer.Entities
{
    public class PromouterUser : UserBase
    {
        public override Checklist MainChecklist
        {
            get { return Checklists.First(); }
        }
    }
}
