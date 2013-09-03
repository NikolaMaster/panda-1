using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Linq.Expressions;
using PandaDataAccessLayer.Entities;

namespace PandaDataAccessLayer.DAL
{
    public class DataAccessLayer<TDbContext> : IDisposable where TDbContext : DbContext, new()
    {
        static DataAccessLayer() 
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        public TDbContext DbContext { get;private set; }

        public DataAccessLayer() : this(new TDbContext())
        {
        }

        public DataAccessLayer(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region CRUD

        public IEnumerable<TEntity> Get<TEntity>()
            where TEntity : class, IGuidIdentifiable
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IGuidIdentifiable
        {
            return DbContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Create<TEntity>(TEntity entity) 
            where TEntity : class, IGuidIdentifiable, new()
        {
            DbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Create<TEntity>(TEntity entity, Func<TEntity, TEntity> func) 
            where TEntity : class, IGuidIdentifiable, new()
        {
            return Create(func(entity));
        }

        public void Update<TEntity>(Expression<Func<TEntity, bool>> filter, Action<TEntity> update)
            where TEntity : class, IGuidIdentifiable
        {
            var set = DbContext.Set<TEntity>();
            foreach (var item in set.Where(filter))
            {
                update(item);
            }
        }

        public TEntity Delete<TEntity>(TEntity entity) 
            where TEntity : class, IGuidIdentifiable
        {
            var set = DbContext.Set<TEntity>();
            set.Remove(entity);
            return entity;
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> filter) 
            where TEntity : class, IGuidIdentifiable
        {
            var set = DbContext.Set<TEntity>();
            foreach (var item in DbContext.Set<TEntity>().Where(filter))
            {
                set.Remove(item);    
            }
        }

        #endregion

        #region CRUD by Id

        public TEntity GetById<TEntity>(Guid id) 
            where TEntity : class, IGuidIdentifiable
        {
            return DbContext.Set<TEntity>().Single(x => x.Id == id);
        }

        public void DeleteById<TEntity>(Guid id) 
            where TEntity : class, IGuidIdentifiable
        {
            DbContext.Set<TEntity>().Remove(GetById<TEntity>(id));
        }

        public void UpdateById<TEntity>(Guid id, Action<TEntity> updateExpression) 
            where TEntity : class, IGuidIdentifiable
        {
            updateExpression(GetById<TEntity>(id));
        }

        #endregion

        #region Code
        
        public TEntity Get<TEntity>(string code)
            where TEntity : class, ICodeIdentifiable
        {
            return DbContext.Set<TEntity>().Single(x => x.Code == code);
        }
        #endregion

        #region other

        public IEnumerable<TEntity> TopRandom<TEntity>(int count)
            where TEntity : class, IGuidIdentifiable
        {
            return DbContext.Set<TEntity>().OrderBy(x => new Guid()).Take(count).ToList();
        }

        public int Count<TEntity>()
            where TEntity : class, IGuidIdentifiable
        {
            return DbContext.Set<TEntity>().Count();
        }

        public int Count<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IGuidIdentifiable
        {
            return DbContext.Set<TEntity>().Count(filter);
        }
        #endregion

        public void Dispose()
        {
            if (DbContext != null)
                DbContext.Dispose();
            DbContext = null;
        }
    }
}
