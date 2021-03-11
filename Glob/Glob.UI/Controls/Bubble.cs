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
    public partial class Bubble : UserControl
    {
        public MessageType Type { get; private set; }
        public Bubble()
        {
            InitializeComponent();
        }

        public Bubble(string message, string time, MessageType type)
        {
            InitializeComponent();
            Type = type;
            messagelbl.Text = message;
            timelbl.Text = time;

            if(type == MessageType.In)
            {
                this.BackColor = Color.FromArgb(35, 100, 204);
            }
            else
            {
                this.BackColor = Color.Gray;
            }

            SetHeight();
        }

        public enum MessageType
        {
            In,
            Out
        }

        void SetHeight()
        {
            messagelbl.Width = this.Width - 2;
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(messagelbl.Text, messagelbl.Font, messagelbl.Width);

            messagelbl.Height = int.Parse(Math.Round(size.Height + 3, 0).ToString());
            timelbl.Top = messagelbl.Bottom + 5;
            this.Height = timelbl.Bottom + 5;
        }

        private void Bubble_Resize(object sender, EventArgs e)
        {
            SetHeight();
        }
    }
}
