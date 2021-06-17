using Mensahero.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensahero.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) {
            var users = new string[] { message.ToUserId, message.FromUserId };
            //await Clients.Users(users).SendAsync("ReceivedMessage", message);
            await Clients.All.SendAsync("ReceivedMessage", message);
        }

        
    }
}
