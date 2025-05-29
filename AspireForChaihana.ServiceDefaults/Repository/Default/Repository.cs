using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository.Default
{

	public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
	where TEntity : class
	where TContext : DbContext
	{
		protected readonly TContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public Repository(TContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
		public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
		public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
		public void Update(TEntity entity) => _dbSet.Update(entity);
		public void Delete(TEntity entity) => _dbSet.Remove(entity);
		public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
	}
}
