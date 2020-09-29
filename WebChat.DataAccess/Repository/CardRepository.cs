using WebChat.DataAccess.Config;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;

namespace WebChat.DataAccess.Repository
{
	public class CardRepository : BaseRepository<Card>, ICardRepository
	{
		public CardRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}