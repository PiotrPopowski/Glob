using Glob.Infrastructure.Services;
using Glob.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Glob.UI.Controls;
using System.Windows.Forms;
using static Glob.Infrastructure.Services.MessageService;
using Glob.Core.Domain;

namespace Glob.UI
{
    public partial class MainForm : BaseForm
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly Color _normalBtnContact = Color.White;
        private readonly Color _activeBtnContact = Color.FromArgb(224, 224, 224);
        private readonly ActiveButtonChanger activeButtonChanger;

        private Contact ActiveContact { get; set; }

        public MainForm(IUserService userService, IMessageService messageService): base()
        {
            _userService = userService;
            _messageService = messageService;
            _messageService.MessageReceived += onMessageReceived;
            _messageService.Initialize();
            this.InitializeComponent();

            this.chatbox1.SendBtnClicked += onSendBtnClicked;
            activeButtonChanger = new ActiveButtonChanger(_normalBtnContact, _activeBtnContact);
            foreach(var contact in _userService.User.Contacts)
            {
                var x = new ContactControl(contact);
                x.Dock = DockStyle.Top;
                x.Click += contactBtn_Click;
                this.contactPanel.Controls.Add(x);
            }
        }

        private async void onSendBtnClicked(object source, Chatbox.MessageSentEventArgs e)
        {
            var x = ActiveContact;
            await _messageService.Send(x, e.Message);
        }

        private async void contactBtn_Click(object sender, EventArgs e)
        {
            ContactControl control = (ContactControl)sender;
            ActiveContact = control.Contact;
            activeButtonChanger.ChangeButton(control.Button);

            var conversation = await _messageService.GetChatAsync(control.Contact.Login);
            chatbox1.SetChat(conversation);
        }

        private void addContactBtn_Click(object sender, EventArgs e)
        {
            using(Form f = new AddContactForm(_userService))
            {
                f.ShowDialog();
                f.Activate();
            }
            if(this.contactPanel.Controls.Count < _userService.User.Contacts.Count())
            {
                var contactControl = new ContactControl(_userService.User.Contacts.Last());
                contactControl.Dock = DockStyle.Top;
                contactControl.Click += contactBtn_Click;
                this.contactPanel.Controls.Add(contactControl);
            }
        }

        private void contactControl_Load(object sender, EventArgs e)
        {
            
        }

        private void onMessageReceived(object sender, MsgReceivedEventArgs e)
        {
            if(e.Sender == ActiveContact.Login)
            {
                chatbox1.AddMessage(e.Message.Data, e.Message.SentTime.ToString("MM/dd HH:mm"));
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
