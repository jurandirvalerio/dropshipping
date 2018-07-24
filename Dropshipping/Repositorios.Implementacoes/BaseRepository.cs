using System;
using System.Data.Entity;
using System.Linq;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
		where TEntity : Entidade 
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
			entity.DataCriacao = DateTime.Now;
			Context.Set<TEntity>().Add(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public virtual void Edit(TEntity entity)
		{
			entity.DataAtualizacao = DateTime.Now;
			Context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Save()
		{
			Context.SaveChanges();
		}
	}
}