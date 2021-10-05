using System.Threading.Tasks;
using WebChat.ViewModels;

namespace WebChat.BusinessLogic.Services.Interfaces
{
    public interface IChatService
    {
        Task Create(MessageModel request);
    }
}