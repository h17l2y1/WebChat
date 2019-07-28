using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.ViewModels.Message;

namespace WebChat.BusinessLogic.Services
{

    public class MessageService : IMessageService
    {
        public Task Edit(EditMessageView view)
        {
            throw new NotImplementedException();
        }

        public Task Remove(RemoveMessageView view)
        {
            throw new NotImplementedException();
        }

        public async Task Send(SendMessageView view)
        {
            throw new NotImplementedException();
        }
    }
}
