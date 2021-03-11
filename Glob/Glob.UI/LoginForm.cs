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

namespace Glob.UI
{
    public partial class LoginForm : BaseForm
    {
        private readonly IUserService _userService;

        public LoginForm(IUserService userService): base()
        {
            _userService = userService;
            this.InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await _userService.Login(loginInput.Text, passwordInput.Text);
            }catch(ArgumentException ex)
            {
                this.loginInput.Clear();
                this.passwordInput.Clear();
                MessageBox.Show(ex.Message, "Nieudane logowanie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            goToForm(typeof(MainForm));
        }
    }
}
