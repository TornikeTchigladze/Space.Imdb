using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Space.Imdb.DB.Contracts.Interfaces.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {
        int Count { get; }
        IQueryable<TModel> All();
        TModel GetById(object id);
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null);
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, string includeProperties = "");
        IQueryable<TModel> Filter(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> Filter(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includes);
        IQueryable<TModel> Filter(Expression<Func<TModel, bool>> filter, out int total, int index = 0, int size = 50);
        bool Contains(Expression<Func<TModel, bool>> predicate);
        TModel Find(Expression<Func<TModel, bool>> predicate);
        void Create(TModel entity);
        void Delete(object id);
        void Delete(TModel entity);
        void Delete(Expression<Func<TModel, bool>> predicate);
        void Update(TModel entityToUpdate);
    }
}
