using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Puppet3
{
    public partial class CustomForm : Form
    {
        private List<Button> soundButtons = new List<Button>();
        private void SoundButtonsInit()
        {
            List<Button> list = new List<Button>() {
                button5, button11, button17, button23, button29,
                button35, button41, button47, button53, button59
            };
            soundButtons.AddRange(list);
            int i = 0;
            foreach(Button button in soundButtons)
            {
                if (File.Exists(CustomSounds.FullPath[i]))
                {
                    button.Text = resetText;
                }
                else
                {
                    button.Text = initialText;
                }
                i++;
            }
        }
    }
}
