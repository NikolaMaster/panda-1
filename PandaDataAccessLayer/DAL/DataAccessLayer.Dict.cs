using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer : DataAccessLayerBase<MainDbContext>
    {
        public KeyValuePair<DictGroup, IEnumerable<DictValue>> Create(DictGroup dictGroup, IEnumerable<DictValue> values)
        {
            var newDictGroup = Create<DictGroup>(dictGroup);
            foreach (var value in values)
            {
                value.DictGroup = newDictGroup;
                Create(value);
            }
            return new KeyValuePair<DictGroup, IEnumerable<DictValue>>(newDictGroup, values);
        }
    }
}
