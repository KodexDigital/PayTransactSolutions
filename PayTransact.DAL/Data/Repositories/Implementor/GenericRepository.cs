using Microsoft.EntityFrameworkCore;
using PayTransact.Persistence.DAL;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PayTransact.Persistence.Data.Repositories.Implementor
{
	public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel: class
	{
		private readonly AppDbContext dbContext;
		internal protected DbSet<TModel> dbSet;
		private IQueryable<TModel> query = null;

		public GenericRepository(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
			dbSet = dbContext.Set<TModel>();

		}
		public void Add(TModel entity)
		{
			dbSet.Add(entity);
		}

		public TModel Get(Guid id) => dbSet.Find(id);

		public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null, string includeProperties = null)
		{
			query = dbSet;
			if (filter != null)
				query.Where(filter);
			if (includeProperties != null)
				foreach (var includes in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) //include properties will be comma seperated
					query.Include(includes);
			if (orderBy != null)
				return orderBy(query).ToList();

			return query.ToList();
		}

		public TModel GetFirstOrDefault(Expression<Func<TModel, bool>> filter = null, string includesProperties = null)
		{
			query = dbSet;
			if (filter != null)
				query.Where(filter);

			if (includesProperties != null)
				foreach (var includes in includesProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					query.Include(includes);

			return query.FirstOrDefault();
		}
	}
}
