using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glob.UI.Infrastructure
{
    public class FormManager: IFormManager
    {
        public BaseForm ActiveForm { get; private set; }
        private readonly IServiceProvider _services;
        private RegisterForm registerForm { get; set; }
        private LoginForm loginForm { get; set; }
        private MainForm mainForm { get; set; }

        public FormManager(BaseForm startForm, IServiceProvider services)
        {
            SetActiveForm(startForm);
            _services = services;
        }

        private void ChangeForm(object source, MyEventArgs e)
        {
            if(e.FormName == typeof(LoginForm))
            {
                if (loginForm == null)
                {
                    loginForm = _services.GetRequiredService<LoginForm>();
                }
                SetActiveForm(loginForm);
            }
            if (e.FormName == typeof(RegisterForm))
            {
                if (registerForm == null)
                {
                    registerForm = _services.GetRequiredService<RegisterForm>();
                }
                SetActiveForm(registerForm);
            }
            if (e.FormName == typeof(MainForm))
            {
                if (mainForm == null)
                {
                    mainForm = _services.GetRequiredService<MainForm>();
                }
                SetActiveForm(mainForm);
            }
        }

        private void SetActiveForm(BaseForm form)
        {
            if (ActiveForm == null)
            {
                ActiveForm = form;
                ActiveForm.ChangeForm += ChangeForm;
            }
            else
            {
                ActiveForm.Enabled = false;
                ActiveForm.Visible = false;
                ActiveForm.ChangeForm -= ChangeForm;
                ActiveForm = form;
                ActiveForm.ChangeForm += ChangeForm;
                ActiveForm.ShowDialog();
            }
        }
    }
}
