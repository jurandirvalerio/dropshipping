using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositorios.Contratos
{
	public interface IBaseRepository<TEntity>
		where TEntity : class
	{
		IQueryable<TEntity> GetAll();

		IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeSet);

		void Add(TEntity entity);

		void Delete(TEntity entity);

		void Edit(TEntity entity);

		void Save();
	}
}