using System.Threading.Tasks;
using WebChat.ViewModels.Message;

namespace WebChat.BusinessLogic.Services.Interfaces
{
    public interface IMessageService
    {
         Task Send(SendMessageView view);
         Task Edit(EditMessageView view);
         Task Remove(RemoveMessageView view);
    }
}
