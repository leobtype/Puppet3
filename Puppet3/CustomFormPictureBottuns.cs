using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet3
{
    public partial class CustomForm : Form
    {
        private List<Button> pictureButtons = new List<Button>();
        private void PictureButtonsInit()
        {
            List<Button> list = new List<Button>() {
                button1, button2, button3, button4,
                button7, button8, button9, button10,
                button13, button14, button15, button16,
                button19, button20, button21, button22,
                button25, button26, button27, button28,
                button31, button32, button33, button34,
                button37, button38, button39, button40,
                button43, button44, button45, button46,
                button49, button50, button51, button52,
                button55, button56, button57, button58,
                // button61 to button70 for background
                button61, button62, button63, button64,
                button65, button66, button67, button68,
                button69, button70
            };
            pictureButtons.AddRange(list);
        }
    }
}
