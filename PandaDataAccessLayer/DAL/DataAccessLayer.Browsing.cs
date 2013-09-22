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
            var exists =
                DbContext.Browsing.Any(
                    x => x.What.Id == whatId &&
                            x.When.Year == when.Year &&
                            x.When.Month == when.Month &&
                            x.When.Day == when.Day &&
                            x.Who.Id == whoId);
            if (exists)
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

        public int GetAllBrowsingValuesCount(Guid whatId)
        {
            return DbContext.Browsing.Count(x => x.What.Id == whatId);
        }

        public BrowsingValues GetBrowsingValues(Guid whatId, DateTime start, DateTime end)
        {
#if DEBUG
            //var col = DbContext.Browsing.Where(x => x.Who.Id == whoId && x.When >= start && x.When <= end);
            //var groupBy = col.GroupBy(x => new { x.When.Year, x.When.Month, x.When.Day });
            //var dict = groupBy.ToDictionary(
            //        key => new DateTime(key.Key.Year, key.Key.Month, key.Key.Day),
            //        value => value.ToArray());
            //return dict;
#endif
            var dates = new List<DateTime>();
            var st = start;
            while (st <= end)
            {
                dates.Add(new DateTime(st.Year, st.Month, st.Day));
                st = st.AddDays(1);
            }

            var dbValues = DbContext.Browsing
                .Where(x => x.What.Id == whatId && x.When >= start && x.When <= end)
                .GroupBy(x => new {x.When.Year, x.When.Month, x.When.Day})
                .ToDictionary(
                    key => new DateTime(key.Key.Year, key.Key.Month, key.Key.Day),
                    value => value.ToArray());
            return dates.ToDictionary(
                key => key,
                value => dbValues.ContainsKey(value) ? dbValues[value] : new Browsing[0]);

        }
    }
}
