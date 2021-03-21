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
    public partial class RegisterForm : BaseForm
    {
        private readonly IUserService _userService;
        public RegisterForm(IUserService userService): base()
        {
            _userService = userService;
            this.InitializeComponent();
        }

        private async void acceptBtn_Click(object sender, EventArgs e)
        {
            if(passwordInput.Text != repeatPasswordInput.Text)
            {
                MessageBox.Show("Hasła nie są identyczne", "Błąd", MessageBoxButtons.OK);
                return;
            }
            await _userService.Register(loginInput.Text, firstNameInput.Text, lastNameInput.Text, passwordInput.Text);
            goToForm(typeof(LoginForm));
        }

        private void passwordInput_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
