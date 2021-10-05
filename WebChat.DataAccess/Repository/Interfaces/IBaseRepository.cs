using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebChat.DataAccess.Repository.Interfaces
{
	public interface IBaseRepository<TEntity>
	{
		Task<TEntity> GetById(string id);

		Task<IEnumerable<TEntity>> GetAll();

		Task Create(TEntity entity);

		Task Update(TEntity entity);

		Task Delete(string id);
	}
}
