using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public class Constants<TDbContext> where TDbContext : DbContext, new()
    {
        private DAL<TDbContext> mDal;

        private Constants() { }

        internal Constants(DAL<TDbContext> dal)
        {
            mDal = dal;
        }

        public Photo DefaultAvatar
        {
            get { return mDal.DbContext.Set<Photo>().Single(x => x.SourceUrl == MainInitializer.DefaultAvatarImage); }
        }
    }
}
