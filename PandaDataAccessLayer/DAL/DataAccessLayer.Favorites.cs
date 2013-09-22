using System;
using System.Collections.Generic;
using System.Data;
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

        public bool CheckMaxLikes(UserBase user)
        {
            var f = GetUserFavorites(user);
            return user.MaxLikes > f.Count();
        }

        public bool CheckMaxLikes(Guid userId)
        {
            var user = FindUserBase(userId);
            return CheckMaxLikes(user);
        }

        public enum AddToFavoritesResult
        {
            WrongTypes,
            NeedToBuy,
            Ok
        }

        public AddToFavoritesResult AddToFavorites(Guid ownerId, Guid likeId)
        {
            var owner = FindUserBase(ownerId);
            var like = FindUserBase(likeId);

            if (owner is PromouterUser && like is PromouterUser)
            {
                return AddToFavoritesResult.WrongTypes;
            }

            if (owner is EmployerUser && like is EmployerUser)
            {
                return AddToFavoritesResult.WrongTypes;
            }

            if (CheckMaxLikes(owner))
            {
                //if already added
                if (DbContext.Favorites.Any(x => x.Owner.Id == owner.Id && x.Like.Id == like.Id))
                {
                    return AddToFavoritesResult.Ok;
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
                return AddToFavoritesResult.NeedToBuy;
            }
            return AddToFavoritesResult.Ok;
        }

        public enum DeleteFromFavoritesResult
        {
            Ok,
            NotFound
        }

        public DeleteFromFavoritesResult DeleteFromFavorite(Guid id)
        {
            var toDelete = GetById<Favorite>(id);
            if (toDelete == null)
            {
                return DeleteFromFavoritesResult.NotFound;
            }
            DbContext.Favorites.Remove(toDelete);
            DbContext.SaveChanges();
            return DeleteFromFavoritesResult.Ok;
        }

        public enum BuyFavoritesResult
        {
            NotEnoughMoney,
            Ok
        }

        public BuyFavoritesResult BuyFavorites(Guid userId, int price, int count)
        {
            var user = FindUserBase(userId);
            var toPay = price*count;
            if (toPay > user.Coins)
            {
                return BuyFavoritesResult.NotEnoughMoney;
            }

            user.Coins -= toPay;
            user.MaxLikes += count;
            DbContext.Entry(user).State = EntityState.Modified;
            DbContext.SaveChanges();
            return BuyFavoritesResult.Ok;
        }
    }
}
