using WebChat.DataAccess.Domain;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;

namespace WebChat.DataAccess.Repository.Entity
{
	public class UserEntityRepository : BaseEntityRepository<User>, IUserRepository
	{
		public UserEntityRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
