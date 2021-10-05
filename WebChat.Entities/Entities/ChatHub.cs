using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebChat.Entities.Entities
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receivedMessage", message);
        
    }
}