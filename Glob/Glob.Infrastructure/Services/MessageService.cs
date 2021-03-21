using Glob.Core.Domain;
using Glob.Infrastructure.Framework;
using Glob.Infrastructure.Settings;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly UserSettings _userSettings;
        private readonly ICryptographyProvider _cryptographyProvider;
        private List<Conversation> conversations;

        private HubConnection _signalR;

        public delegate void MessageReceivedEventHandler(object source, MsgReceivedEventArgs e);
        public event MessageReceivedEventHandler MessageReceived;

        public MessageService(UserSettings userSettings, ICryptographyProvider cryptographyProvider)
        {
            _userSettings = userSettings;
            _cryptographyProvider = cryptographyProvider;
        }

        public async void Initialize()
        {
            conversations = new List<Conversation>();
            _signalR = new HubConnectionBuilder().WithUrl(ApiEndpoints.SignalChat,
                options =>
                {
                    options.Headers.Add("Auth", _userSettings.User.Token);
                    options.HttpMessageHandlerFactory = innerHandler =>
                    {
                        return new CustomHttpHandler(new AuthenticationHeaderValue("Bearer", _userSettings.User.Token), innerHandler);
                    };
                }).WithAutomaticReconnect().Build();
            _signalR.On<string, string>("ReceiveMessage", ReceiveMessage);
            _signalR.Reconnected += async (connectionId) => { await _signalR.InvokeAsync("Reconnect"); };

            await _signalR.StartAsync();
            await _signalR.InvokeAsync("SetName", _userSettings.User.Login);
        }

        public async Task<IList<Conversation>> GetAllAsync()
        {
            if (conversations.Count == 0)
                await refreshConversations();
            return conversations.AsReadOnly();
        }

        public async Task<Conversation> GetChatAsync(string user)
        {
            var conversation = conversations.SingleOrDefault(x => x.Contact.Login == user);
            if (conversation == null)
            {
                await refreshConversations();
                conversation = conversations.SingleOrDefault(x => x.Contact.Login == user);
            }
            return conversation;
        }

        public async Task Send(Contact toUser, string message)
        {
            var conversation = await GetChatAsync(toUser.Login);
            conversation.Messages.Add(new Message(_userSettings.User.Login, toUser.Login, message));

            var key = _userSettings.Keys[toUser.Login];
            var encryptedMessage = _cryptographyProvider.AES.Encrypt(message, key.Key, key.IV);
            var signature = _cryptographyProvider.RSA.SignData(encryptedMessage, _userSettings.User.PrivateKey);
            await _signalR.InvokeAsync("SendMessage", toUser.Login, new SignedData(encryptedMessage, signature));
        }

        private async void ReceiveMessage(string contact, string message)
        {
            var key = _userSettings.Keys[contact];
            var decryptedMessage = _cryptographyProvider.AES.Decrypt(message, key.Key, key.IV);
            var msg = new Message(contact, _userSettings.User.Login, decryptedMessage);
            var conversation = await GetChatAsync(contact);
            conversation.Messages.Add(msg);

            MessageReceived.Invoke(this, new MsgReceivedEventArgs(contact, msg));
        }

        private async Task refreshConversations()
        {
            conversations = await HttpClientWrapper.GetAsync<List<Conversation>>(ApiEndpoints.AllConversation);
            if (conversations != null)
            {
                foreach (var conv in conversations)
                {
                    var key = _userSettings.Keys[conv.Contact.Login];
                    foreach (var msg in conv.Messages)
                    {
                        msg.Data = _cryptographyProvider.AES.Decrypt(msg.Data, key.Key, key.IV);
                    }
                }
            }
        }

        public class MsgReceivedEventArgs : EventArgs
        {
            public string Sender { get; set; }
            public Message Message { get; set; }

            public MsgReceivedEventArgs(string sender, Message message)
            {
                Sender = sender;
                Message = message;
            }
        }
    }
}
