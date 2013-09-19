using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer.Entities;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer //: DataAccessLayerBase<MainDbContext>
    {
        public IEnumerable<Favorite> GetAllFavorites()
        {
            var result = DbContext.Favorites.ToList();
            return result;
        }

        public IEnumerable<Favorite> GetUserFavorites(UserBase user)
        {
            var result = DbContext.Favorites.Where(x => x.Owner.Id == user.Id).ToList();
            return result;
        }

        public IEnumerable<Favorite> GetUserFavorites(Guid userId)
        {
            var user = FindUserBase(userId);
            return GetUserFavorites(user);
        }

        public bool CanAddToFavorites(UserBase user)
        {
            var f = GetUserFavorites(user);
            return user.MaxLikes > f.Count();
        }

        public bool CanAddToFavorites(Guid userId)
        {
            var user = FindUserBase(userId);
            return CanAddToFavorites(user);
        }

        public bool AddToFavorites(Guid ownerId, Guid likeId)
        {
            var owner = FindUserBase(ownerId);
            var like = FindUserBase(likeId);

            if (owner is PromouterUser && like is PromouterUser)
            {
#if DEBUG
                throw new Exception("Promouter can not add Promouter as favorite!");
#endif
                return false;
            }

            if (owner is EmployerUser && like is EmployerUser)
            {
#if DEBUG
                throw new Exception("Employer can not add Employer as favorite!");
#endif
                return false;
            }

            if (CanAddToFavorites(owner))
            {
                //if already added
                if (DbContext.Favorites.Any(x => x.Owner.Id == owner.Id && x.Like.Id == like.Id))
                {
                    return true;
                }
                DbContext.Favorites.Add(new Favorite
                {
                    Owner = owner,
                    Like = like
                });
                DbContext.SaveChanges();
            }
            else
            {
#if DEBUG
                throw new Exception("User can not add more favorites!");
#endif
                return false;
            }
            return true;
        }

        public bool DeleteFromFavorite(Guid id)
        {
            var toDelete = GetById<Favorite>(id);
            if (toDelete == null)
            {
#if DEBUG
                throw new Exception("Favorite to delete not found!");
#endif
                return false;
            }
            DbContext.Favorites.Remove(toDelete);
            DbContext.SaveChanges();
            return true;
        }
    }
}
