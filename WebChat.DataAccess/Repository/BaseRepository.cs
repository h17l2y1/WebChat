using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DataAccess.Config;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Interfaces;

namespace WebChat.DataAccess.Repository
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
	{
		private ApplicationDbContext _сontext { get; set; }
		protected DbSet<TEntity> _dbSet { get; set; }

		public BaseRepository(ApplicationDbContext dbContext)
		{
			_сontext = dbContext;
			_dbSet = _сontext.Set<TEntity>();
		}

		public async Task Create(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await _сontext.SaveChangesAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<TEntity> GetById(string id)
		{
			TEntity entity = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
			return entity;
		}

		public async Task Update(TEntity entity)
		{
			_dbSet.Update(entity);
			await _сontext.SaveChangesAsync();
		}

		public async Task Delete(string id)
		{
			TEntity entity = _dbSet.SingleOrDefault(s => s.Id == id);
			_dbSet.Remove(entity);
			await _сontext.SaveChangesAsync();
		}

	}
}
