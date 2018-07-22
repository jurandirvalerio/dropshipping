using System;
using System.Data.Entity;
using System.Linq;
using Repositorio.Contratos;

namespace Repositorio.Implementacoes
{
	public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
		where TEntity : class 
		where TContext : DbContext, new()
	{
		public TContext Context { get; set; } = new TContext();

		public virtual IQueryable<TEntity> GetAll()
		{

			IQueryable<TEntity> query = Context.Set<TEntity>();
			return query;
		}

		public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
		{

			IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
			return query;
		}

		public virtual void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public virtual void Edit(TEntity entity)
		{
			Context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Save()
		{
			Context.SaveChanges();
		}
	}
}