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
using System.Windows.Forms;

namespace Glob.UI
{
    public partial class BaseForm : Form
    {
        public delegate void ChangeFormEventHandler(object source, MyEventArgs e);
        public event ChangeFormEventHandler ChangeForm;

        public BaseForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #region Code for moveable topPanel
        public static event EventHandler PanelDragging;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (PanelDragging != null)
                    PanelDragging(null, EventArgs.Empty);
            }
        }

        public static void HandleMouseMove(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            HandleMouseMove(Handle);
        }

        #endregion

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        protected void goToForm(Type form)
        {
            ChangeForm(this, new MyEventArgs(form));
        }
    }

    public class MyEventArgs: EventArgs
    {
        public Type FormName { get; set; }
        public MyEventArgs(Type formName)
        {
            FormName = formName;
        }
    }
}
