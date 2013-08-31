using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public static class UserDAL
    {
        private const string MainAlbumName = "Основной альбом";
        private const int OnlineTimeout = 2 * 60; 

        public static TEntity Create<TEntity>(this DAL<MainDbContext> dal, TEntity user, SeoEntry seo)
             where TEntity : UserBase
        {
            user.SeoEntry = dal.Create(seo);
            if (user.Checklists.Count == 0)
            {
                user.Checklists.Add(dal.CreateChecklist(user, new List<AttribValue>()));
            }
            if (user.Albums.Count == 0)
            {
                user.Albums.Add(dal.Create<Album>(new Album()
                    {
                        Name = MainAlbumName,
                        User = user,
                    }));
            }
            if (user.Avatar == null)
            {
                user.Avatar = dal.Constants.DefaultAvatar;
            }
            return dal.Create<TEntity>(user);
        }

        public static int OnlineUsers<TEntity>(this  DAL<MainDbContext> dal)
             where TEntity : UserBase
        {
            return dal.DbContext.Set<TEntity>().Count(x => x.Sessions.Any(y => EntityFunctions.DiffSeconds(DateTime.Now, y.LastHit) < OnlineTimeout));
        }
    }
}
