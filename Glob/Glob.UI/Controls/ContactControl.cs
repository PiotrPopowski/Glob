using Glob.Core.Domain;
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
    public partial class ContactControl : UserControl
    {
        public Contact Contact { get; private set; }

        public ContactControl()
        {
            InitializeComponent();
            this.Button = this.button1;
        }

        public ContactControl(Contact contact)
        {
            InitializeComponent();
            this.button1.Text = contact.Login;
            Button = this.button1;
            Contact = contact;
        }

        public Button Button { get; private set; }

        private void ContactControl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
