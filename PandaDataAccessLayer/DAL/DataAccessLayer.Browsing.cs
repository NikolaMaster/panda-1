using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer.Entities;
using BrowsingValues = System.Collections.Generic.Dictionary<System.DateTime, PandaDataAccessLayer.Entities.Browsing[]>;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer
    {
        public bool CreateBrowsing(Guid whoId, Guid whatId)
        {
            var who = GetById<UserBase>(whoId);
            var what = GetById<UserBase>(whatId);

            if (who == null)
            {
#if DEBUG
                throw new Exception("Who not found!");
#endif
                return false;
            }

            if (what == null)
            {
#if DEBUG
                throw new Exception("What not found!");
#endif
                return false;
            }

            var when = DateTime.UtcNow;
            var oldB =
                DbContext.Browsing.FirstOrDefault(
                    x => x.When.Year == when.Year && x.When.Month == when.Month && x.When.Day == when.Day);
            if (oldB != null)
            {
                return false;
            }

            var b = new Browsing
            {
                When = DateTime.UtcNow,
                What = what,
                Who = who
            };
            DbContext.Browsing.Add(b);
            DbContext.SaveChanges();
            return true;
        }

        public BrowsingValues GetBrowsingValues(Guid whoId, DateTime start, DateTime end)
        {
            return DbContext.Browsing
                .Where(x => x.Who.Id == whoId && x.When >= start && x.When <= end)
                .GroupBy(x => new {x.When.Year, x.When.Month, x.When.Day})
                .ToDictionary(
                    key => new DateTime(key.Key.Year, key.Key.Month, key.Key.Day),
                    value => value.ToArray());
        }
    }
}
