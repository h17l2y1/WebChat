using WebChat.DataAccess.Config;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;

namespace WebChat.DataAccess.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}