using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PayTransact.Persistence.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TModel> where TModel:class
    {
        void Add(TModel entity);
        TModel Get(Guid id);
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            string includeProperties = null);
        TModel GetFirstOrDefault(Expression<Func<TModel, bool>> filter = null,
            string includesProperties = null);
    }
}
