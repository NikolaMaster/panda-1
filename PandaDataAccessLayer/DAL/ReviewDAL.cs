using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public static class ReviewDAL
    {
        public static IEnumerable<TEntity> Get<TEntity>(this  DAL<MainDbContext> dal, Guid userId)
            where TEntity : Review
        {
            return dal.DbContext.Set<TEntity>().Where(x => x.Users.Any(y => y.Id == userId)).ToList();
        }
    }
}
