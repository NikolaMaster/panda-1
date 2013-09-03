using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public interface ICodeIdentifiable
    {
        string Code { get; set; }
    }
}
