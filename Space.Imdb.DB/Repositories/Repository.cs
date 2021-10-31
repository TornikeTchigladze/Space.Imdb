using Microsoft.EntityFrameworkCore;
using Space.Imdb.DB.Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Space.Imdb.DB.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext DbContext;
        public virtual int Count
        {
            get { return DbContext.Set<TModel>().Count(); }
        }
        protected Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbContext.Database.EnsureCreated();
        }
        protected T GetContext<T>() where T : class
        {
            return (T)Convert.ChangeType(DbContext, Type.GetTypeCode(typeof(T)));
        }
        public virtual IQueryable<TModel> All()
        {
            return DbContext.Set<TModel>();
        }
        public virtual TModel GetById(object id)
        {
            return DbContext.Set<TModel>().Find(id);
        }
        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null)
        {
            IQueryable<TModel> query = DbContext.Set<TModel>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy != null ? orderBy(query).AsQueryable() : query.AsQueryable();
        }
        public virtual IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = DbContext.Set<TModel>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual IQueryable<TModel> Filter(Expression<Func<TModel, bool>> predicate)
        {
            return DbContext.Set<TModel>().Where(predicate).AsQueryable();
        }
        public virtual IQueryable<TModel> Filter(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includes)
        {
            IQueryable<TModel> query = DbContext.Set<TModel>();
            if (includes != null)
            {
                foreach (Expression<Func<TModel, object>> include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.Where(predicate).AsQueryable();
        }
        public virtual IQueryable<TModel> Filter(Expression<Func<TModel, bool>> filter, out int total, int index = 0, int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null ? DbContext.Set<TModel>().Where(filter).AsQueryable()
                : DbContext.Set<TModel>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }
        public bool Contains(Expression<Func<TModel, bool>> predicate)
        {
            return DbContext.Set<TModel>().Any(predicate);
        }
        public virtual TModel Find(Expression<Func<TModel, bool>> predicate)
        {
            return DbContext.Set<TModel>().FirstOrDefault(predicate);
        }
        public virtual void Create(TModel entity)
        {
            DbContext.Set<TModel>().Add(entity);
        }
        public virtual void Delete(object id)
        {
            var entityToDelete = GetById(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TModel entity)
        {
            DbContext.Set<TModel>().Remove(entity);
        }
        public virtual void Delete(Expression<Func<TModel, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                DbContext.Set<TModel>().Remove(entity);
            }
        }
        public void Update(TModel entityToUpdate)
        {
            DbContext.Attach(entityToUpdate);
            DbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
