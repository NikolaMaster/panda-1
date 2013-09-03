using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer
    {
        public Constants Constants { get; private set; }

        public DataAccessLayer()
            : base()
        {
            Constants = new Constants(this);
        }

        public DataAccessLayer(MainDbContext dbContext)
            : base(dbContext)
        {
            Constants = new Constants(this);
        }
    }
}
