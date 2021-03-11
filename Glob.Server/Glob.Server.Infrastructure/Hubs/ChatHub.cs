using Glob.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Hubs
{
    public class ChatHub: Hub
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        [Authorize]
        public async Task<Task> SendMessage(string user, string message)
        {
            await _chatService.Send(this.Context.User.Identity.Name, user, message);
            var connectionId = users.LastOrDefault(x => x.Value == user).Key;
            return Clients.Clients(connectionId).SendAsync("ReceiveMessage", users[Context.ConnectionId], message);
        }

        [Authorize]
        public void SetName(string name)
        {
            users[Context.ConnectionId] = this.Context.User.Identity.Name;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            users.Remove(this.Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
