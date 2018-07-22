using System;
using System.Linq;

namespace Repositorios.Contratos
{
	public interface IBaseRepository<TEntity>
		where TEntity : class
	{
		IQueryable<TEntity> GetAll();

		IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

		void Add(TEntity entity);

		void Delete(TEntity entity);

		void Edit(TEntity entity);

		void Save();
	}
}