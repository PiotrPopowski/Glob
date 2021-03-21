using Glob.Core.Domain;
using Glob.Infrastructure.Services;
using Glob.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glob.UI.Controls
{
    public partial class Chatbox : UserControl
    {
        private Bubble lastBubble { get; set; }
        private int bubbleWidth;

        public delegate void SendBtnClick(object source, MessageSentEventArgs e);
        public event SendBtnClick SendBtnClicked;

        public Chatbox()
        {
            if(!this.DesignMode)
                InitializeComponent();
            bubbleWidth = this.Width - 65;
            //If in Design mode set the if statement to true
/*            if (false)
            {
                AddMessage("Żyjesz tam?", "25/01 15:33");
                AddMessage("HALO", "25/01 15:33");
                SendMessage("ta", "26/02 12:23");
            }*/
        }

        public void SetChat(Conversation messages)
        {
            ClearChat();
            if (messages == null) 
                return;
            foreach(var msg in messages.Messages)
            {
                var time = msg.SentTime.ToString("MM/dd HH:mm");
                if (msg.Sender == messages.Contact.Login)
                {
                    AddMessage(msg.Data, time);
                }
                else
                {
                    SendMessage(msg.Data, time);
                }
            }
        }

        public void ClearChat()
        {
            this.topPanel.Controls.Clear();
            lastBubble = null;
        }

        public void AddMessage(string message, string time)
        {
            Bubble bubble = new Bubble(message, time, Bubble.MessageType.In);
            bubble.Width = bubbleWidth;
            if (lastBubble == null)
            {
                bubble.Location = new Point(5, 0);
                bubble.Top = 10;
            }
            else
            {
                bubble.Location = lastBubble.Location;
                if(lastBubble.Type == Bubble.MessageType.Out)
                {
                    bubble.Left -= 10;
                }
                bubble.Top = lastBubble.Bottom + 10;
            }

            this.topPanel.Controls.Add(bubble);
            topPanel.VerticalScroll.Value = topPanel.VerticalScroll.Maximum;

            lastBubble = bubble;
        }

        public void SendMessage(string text, string time)
        {
            Bubble bubble = new Bubble(text, time, Bubble.MessageType.Out);
            bubble.Width = bubbleWidth;
            if (lastBubble == null)
            {
                bubble.Location = new Point(15, 0);
                bubble.Top = 10;
            }
            else
            {
                bubble.Location = lastBubble.Location;
                if(lastBubble.Type == Bubble.MessageType.In)
                {
                    bubble.Left += 10;
                }
                bubble.Top = lastBubble.Bottom + 10;
            }

            this.topPanel.Controls.Add(bubble);
            topPanel.VerticalScroll.Value = topPanel.VerticalScroll.Maximum;

            lastBubble = bubble;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.messageBox.Text))
            {
                var time = DateTime.Now.ToString("dd/MM HH:mm");
                SendMessage(this.messageBox.Text, time);
                SendBtnClicked.Invoke(this, new MessageSentEventArgs(this.messageBox.Text));
            }
            this.messageBox.Clear();
        }

        public class MessageSentEventArgs: EventArgs
        {
            public string Message { get; set; }

            public MessageSentEventArgs(string msg)
            {
                Message = msg;
            }
        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                this.messageBox.Text = String.Join("",this.messageBox.Text.Split('\n'));
                sendBtn_Click(sender, e);
            }
        }
    }
}
