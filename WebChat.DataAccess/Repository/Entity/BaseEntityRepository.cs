using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.DataAccess.Domain;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;

namespace WebChat.DataAccess.Repository.Entity
{
	public abstract class BaseEntityRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
	{
		private ApplicationContext _сontext { get; set; }
		protected DbSet<TEntity> _dbSet { get; set; }

		public BaseEntityRepository(ApplicationContext context)
		{
			_сontext = context;
			_dbSet = _сontext.Set<TEntity>();
		}

		public async Task Add(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await _сontext.SaveChangesAsync();
		}

		public async Task AddRange(IEnumerable<TEntity> entities)
		{
			await _dbSet.AddRangeAsync(entities);
			await _сontext.SaveChangesAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<TEntity> Get(long id)
		{
			return await _dbSet.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<TEntity>> GetRange(IEnumerable<long> entityIdList)
		{
			return await _dbSet.AsQueryable()
				.Where(x => entityIdList.Contains(x.Id))
				.ToListAsync();
		}

		public async Task Update(TEntity entity)
		{
			_dbSet.Update(entity);
			await _сontext.SaveChangesAsync();
		}

		public async Task Remove(TEntity entity)
		{
			_dbSet.Remove(entity);
			await _сontext.SaveChangesAsync();
		}

		public async Task Remove(long id)
		{
			TEntity entity = await Get(id);
			await Remove(entity);
			await _сontext.SaveChangesAsync();
		}

		public async Task RemoveRange(IEnumerable<TEntity> entities)
		{
			_dbSet.RemoveRange(entities);
			await _сontext.SaveChangesAsync();
		}

		public async Task<int> GetCount()
		{
			return await _dbSet.CountAsync();
		}

	}
}
