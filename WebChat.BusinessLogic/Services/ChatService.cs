using System.Threading.Tasks;
using AutoMapper;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;
using WebChat.ViewModels;

namespace WebChat.BusinessLogic.Services
{
    public class ChatService : IChatService
    {
        private readonly IMapper _mapper;
        // private readonly IMessageRepository _messageRepository;
        
        public ChatService(IMapper mapper
            // IMessageRepository messageRepository
            )
        {
            _mapper = mapper;
            // _messageRepository = messageRepository;
        }

        public async Task Create(MessageModel request)
        {
            Message message = _mapper.Map<Message>(request);
            // await _messageRepository.Create(message);
        }
    }
}