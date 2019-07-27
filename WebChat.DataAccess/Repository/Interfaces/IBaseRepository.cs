using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebChat.DataAccess.Repository.Interfaces
{
	public interface IBaseRepository<TEntity>
	{
		Task Add(TEntity entity);

		Task AddRange(IEnumerable<TEntity> entities);

		Task<IEnumerable<TEntity>> GetAll();

		Task<TEntity> Get(long id);

		Task<IEnumerable<TEntity>> GetRange(IEnumerable<long> entityIdList);

		Task Update(TEntity entity);

		Task Remove(TEntity entity);

		Task Remove(long id);

		Task RemoveRange(IEnumerable<TEntity> entities);

		Task<int> GetCount();

	}
}
