using Glob.Server.Core.Domain;
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
        private readonly IUserService _userService;

        public ChatHub(IChatService chatService, IUserService userService)
        {
            _chatService = chatService;
            _userService = userService;
        }

        [Authorize]
        public async Task<Task> SendMessage(string user, SignedData message)
        {
            var sender = await _userService.GetAsync(Context.User.Identity.Name);
            if (Encrypter.VerifySignedData(message.Data, message.Signature, sender.PublicKey) == false)
            {
                return Task.CompletedTask;
            }
            await _chatService.Send(this.Context.User.Identity.Name, user, message.Data);
            var connectionId = users.LastOrDefault(x => x.Value == user).Key;
            return Clients.Clients(connectionId).SendAsync("ReceiveMessage", users[Context.ConnectionId], message.Data);
        }

        [Authorize]
        public void SetName(string name)
        {
            users[Context.ConnectionId] = this.Context.User.Identity.Name;
        }

        [Authorize]
        public void Reconnect()
        {
            var oldUser = users.FirstOrDefault(x => x.Value == this.Context.User.Identity.Name).Key;
            if(oldUser == null)
            {
                return;
            }
            users.Remove(oldUser);
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
