using System.Threading.Tasks;
using WebChat.ViewModels.Chat;

namespace WebChat.BusinessLogic.Services.Interfaces
{
    public interface IChatService
    {
        Task CreateChat(CreateChatView view);
        Task AddUserInChat(AddUserInChatView view);
        Task RemoveFromGroup(RemoveFromChatView view);
        Task Delete(DeleteChatView view);
    }
}
