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
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private void PictureBoxesInit()
        {
            List<PictureBox> list = new List<PictureBox>()
            {
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                pictureBox13, pictureBox14, pictureBox15, pictureBox16,
                pictureBox17, pictureBox18, pictureBox19, pictureBox20,
                pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28,
                pictureBox29, pictureBox30, pictureBox31, pictureBox32,
                pictureBox33, pictureBox34, pictureBox35, pictureBox36,
                pictureBox37, pictureBox38, pictureBox39, pictureBox40,
                // pictureBox41 to pictureBox50 for background
                pictureBox41, pictureBox42, pictureBox43, pictureBox44,
                pictureBox45, pictureBox46, pictureBox47, pictureBox48,
                pictureBox49, pictureBox50
            };
            pictureBoxes.AddRange(list);
        }

    }
}
