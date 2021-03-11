using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glob.UI.Infrastructure
{
    public class ActiveButtonChanger
    {
        public Button ActiveButton { get; private set; }
        public Color ActiveColor { get; set; }
        public Color NormalColor { get; set; }

        public ActiveButtonChanger(Color normalBtnColor, Color activeBtnColor)
        {
            NormalColor = normalBtnColor;
            ActiveColor = activeBtnColor;
        }
        public void ChangeButton(Button btn)
        {
            if(ActiveButton == null)
            {
                ActiveButton = btn;
            }
            ActiveButton.BackColor = NormalColor;
            btn.BackColor = ActiveColor;
            ActiveButton = btn;
        }
        
    }
}
