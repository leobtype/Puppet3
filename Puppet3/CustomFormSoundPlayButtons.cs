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
        private List<Button> soundPlayButtons = new List<Button>();
        private void SoundPlayButtonsInit()
        {
            List<Button> list = new List<Button>() {
                button6, button12, button18, button24, button30,
                button36, button42, button48, button54, button60
            };
            soundPlayButtons.AddRange(list);
        }
    }
}
