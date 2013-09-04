using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer : DataAccessLayerBase<MainDbContext>
    {
        private const string MainAlbumName = "Основной альбом";
        private const int OnlineTimeout = 2 * 60;

        public PromouterUser Create(PromouterUser user)
        {
            if (user.SeoEntry == null)
            {
                user.SeoEntry = Create<SeoEntry>(new SeoEntry { });
            }
            if (user.Checklists.Count == 0)
            {
                user.Checklists.Add(Create(user, new List<AttribValue>()));
            }
            if (user.Albums.Count == 0)
            {
                user.Albums.Add(Create<Album>(new Album()
                {
                    Name = MainAlbumName,
                    User = user,
                }));
            }
            if (user.Avatar == null)
            {
                user.Avatar = Constants.DefaultAvatar;
            }
            DbContext.Users.Add(user);
            return user;
        }

        public EmployerUser Create(EmployerUser user)
        {
            if (user.SeoEntry == null)
            {
                user.SeoEntry = Create<SeoEntry>(new SeoEntry { });
            }
            if (user.Albums.Count == 0)
            {
                user.Albums.Add(Create<Album>(new Album()
                {
                    Name = MainAlbumName,
                    User = user,
                }));
            }
            if (user.Avatar == null)
            {
                user.Avatar = Constants.DefaultAvatar;
            }
            DbContext.Users.Add(user);
            return user;
        }

        public int OnlineUsers()
        {
            return DbContext.Users.Count(x => x.Sessions.Any(y => EntityFunctions.DiffSeconds(DateTime.UtcNow, y.LastHit) < OnlineTimeout));
        }
    }
}
