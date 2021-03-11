using Glob.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glob.UI
{
    public partial class AddContactForm : Form
    {
        private readonly IUserService _userService;

        public AddContactForm()
        {
            InitializeComponent();
        }

        public AddContactForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var contact = await _userService.AddContact(contactLogin.Text);
            if(contact == null)
            {
                MessageBox.Show("Nie znaleziono użytkownika z podanym loginem", "Nie poprawny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void AddContactForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.button1;
        }
    }
}
