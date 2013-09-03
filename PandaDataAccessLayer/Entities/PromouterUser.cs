using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class PromouterUser : UserBase
    {
        public Checklist Checklist 
        {
            get { return Checklists.First(); }
        }
    }
}
