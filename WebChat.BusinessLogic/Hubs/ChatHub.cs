using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebChat.Entities.Entities;

namespace WebChat.BusinessLogic.Hubs
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(Message message) =>
			await Clients.All.SendAsync("receive Message", message);
		

		
	}
}
