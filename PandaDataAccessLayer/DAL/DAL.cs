using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Linq.Expressions;

namespace PandaDataAccessLayer.DAL
{
    public class DAL<TDbContext> : IDisposable where TDbContext : DbContext, new()
    {
        static DAL() 
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        private TDbContext mDbContext;
        private Constants<TDbContext> mConstants;

        public TDbContext DbContext 
        {
            get { return mDbContext; } 
        }

        public Constants<TDbContext> Constants
        {
            get { return mConstants; }
        }

        public DAL() : this(new TDbContext())
        {
            mConstants = new Constants<TDbContext>(this);
        }

        public DAL(TDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        #region CRUD by Id

        public TEntity GetById<TEntity>(Guid id) where TEntity : class, IGuidIdentifiable
        {
            return mDbContext.Set<TEntity>().Single(x => x.Id == id);
        }

        public void DeleteById<TEntity>(Guid id) where TEntity : class, IGuidIdentifiable
        {
            mDbContext.Set<TEntity>().Remove(GetById<TEntity>(id));
        }

        public void UpdateById<TEntity>(Guid id, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class, IGuidIdentifiable
        {
            mDbContext.Set<TEntity>().Update(x => x.Id == id, updateExpression);
        }

        #endregion

        #region CRUD by Entity

        public TEntity Create<TEntity>() where TEntity : class, IGuidIdentifiable
        {
            var set = mDbContext.Set<TEntity>();
            var instance = set.Create();
            set.Add(instance);
            return instance;
        }

        public TEntity Create<TEntity>(TEntity entity) where TEntity : class, IGuidIdentifiable
        {
            var set = mDbContext.Set<TEntity>();
            set.Add(entity);
            return entity;
        }

        public TEntity Create<TEntity>(TEntity entity, Func<TEntity, TEntity> func) where TEntity : class, IGuidIdentifiable
        {
            return Create(func(entity));
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class, IGuidIdentifiable
        {
            var set = mDbContext.Set<TEntity>();
            set.Remove(entity);
            return entity;
        }

        #endregion

        #region other
        public IEnumerable<TEntity> TopRandom<TEntity>(int count)
            where TEntity : class, IGuidIdentifiable
        {
            return mDbContext.Set<TEntity>().OrderBy(x => new Guid()).Take(count).ToList();
        }
        #endregion

        public void Dispose()
        {
            if (mDbContext != null)
                mDbContext.Dispose();
            mDbContext = null;
        }
    }
}
