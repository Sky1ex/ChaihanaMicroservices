using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository.Default
{
	
	public interface IRepository<TEntity, TContext> where TEntity : class
											   where TContext : DbContext
	{
		Task<TEntity?> GetByIdAsync(Guid id);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task SaveChangesAsync();
	}
}
