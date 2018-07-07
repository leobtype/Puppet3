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
        private void SetEvents()
        {
            FormClosed += new FormClosedEventHandler(Form_Closed);

            foreach(Button button in pictureButtons)
            {
                button.DragEnter += new DragEventHandler(Button_DragEnter);
            }
            foreach (Button button in soundButtons)
            {
                button.DragEnter += new DragEventHandler(Button_DragEnter);
            }

            button1.DragDrop += new DragEventHandler(Button1_DragDrop);
            button2.DragDrop += new DragEventHandler(Button2_DragDrop);
            button3.DragDrop += new DragEventHandler(Button3_DragDrop);
            button4.DragDrop += new DragEventHandler(Button4_DragDrop);
            button5.DragDrop += new DragEventHandler(Button5_DragDrop);
            button6.DragDrop += new DragEventHandler(Button6_DragDrop);
            button7.DragDrop += new DragEventHandler(Button7_DragDrop);
            button8.DragDrop += new DragEventHandler(Button8_DragDrop);
            button9.DragDrop += new DragEventHandler(Button9_DragDrop);
            button10.DragDrop += new DragEventHandler(Button10_DragDrop);
            button11.DragDrop += new DragEventHandler(Button11_DragDrop);
            button12.DragDrop += new DragEventHandler(Button12_DragDrop);
            button13.DragDrop += new DragEventHandler(Button13_DragDrop);
            button14.DragDrop += new DragEventHandler(Button14_DragDrop);
            button15.DragDrop += new DragEventHandler(Button15_DragDrop);
            button16.DragDrop += new DragEventHandler(Button16_DragDrop);
            button17.DragDrop += new DragEventHandler(Button17_DragDrop);
            button18.DragDrop += new DragEventHandler(Button18_DragDrop);
            button19.DragDrop += new DragEventHandler(Button19_DragDrop);
            button20.DragDrop += new DragEventHandler(Button20_DragDrop);
            button21.DragDrop += new DragEventHandler(Button21_DragDrop);
            button22.DragDrop += new DragEventHandler(Button22_DragDrop);
            button23.DragDrop += new DragEventHandler(Button23_DragDrop);
            button24.DragDrop += new DragEventHandler(Button24_DragDrop);
            button25.DragDrop += new DragEventHandler(Button25_DragDrop);
            button26.DragDrop += new DragEventHandler(Button26_DragDrop);
            button27.DragDrop += new DragEventHandler(Button27_DragDrop);
            button28.DragDrop += new DragEventHandler(Button28_DragDrop);
            button29.DragDrop += new DragEventHandler(Button29_DragDrop);
            button30.DragDrop += new DragEventHandler(Button30_DragDrop);
            button31.DragDrop += new DragEventHandler(Button31_DragDrop);
            button32.DragDrop += new DragEventHandler(Button32_DragDrop);
            button33.DragDrop += new DragEventHandler(Button33_DragDrop);
            button34.DragDrop += new DragEventHandler(Button34_DragDrop);
            button35.DragDrop += new DragEventHandler(Button35_DragDrop);
            button36.DragDrop += new DragEventHandler(Button36_DragDrop);
            button37.DragDrop += new DragEventHandler(Button37_DragDrop);
            button38.DragDrop += new DragEventHandler(Button38_DragDrop);
            button39.DragDrop += new DragEventHandler(Button39_DragDrop);
            button40.DragDrop += new DragEventHandler(Button40_DragDrop);
            button41.DragDrop += new DragEventHandler(Button41_DragDrop);
            button42.DragDrop += new DragEventHandler(Button42_DragDrop);
            button43.DragDrop += new DragEventHandler(Button43_DragDrop);
            button44.DragDrop += new DragEventHandler(Button44_DragDrop);
            button45.DragDrop += new DragEventHandler(Button45_DragDrop);
            button46.DragDrop += new DragEventHandler(Button46_DragDrop);
            button47.DragDrop += new DragEventHandler(Button47_DragDrop);
            button48.DragDrop += new DragEventHandler(Button48_DragDrop);
            button49.DragDrop += new DragEventHandler(Button49_DragDrop);
            button50.DragDrop += new DragEventHandler(Button50_DragDrop);
            button51.DragDrop += new DragEventHandler(Button51_DragDrop);
            button52.DragDrop += new DragEventHandler(Button52_DragDrop);
            button53.DragDrop += new DragEventHandler(Button53_DragDrop);
            button54.DragDrop += new DragEventHandler(Button54_DragDrop);
            button55.DragDrop += new DragEventHandler(Button55_DragDrop);
            button56.DragDrop += new DragEventHandler(Button56_DragDrop);
            button57.DragDrop += new DragEventHandler(Button57_DragDrop);
            button58.DragDrop += new DragEventHandler(Button58_DragDrop);
            button59.DragDrop += new DragEventHandler(Button59_DragDrop);
            button60.DragDrop += new DragEventHandler(Button60_DragDrop);
            button61.DragDrop += new DragEventHandler(Button61_DragDrop);
            button62.DragDrop += new DragEventHandler(Button62_DragDrop);
            button63.DragDrop += new DragEventHandler(Button63_DragDrop);
            button64.DragDrop += new DragEventHandler(Button64_DragDrop);
            button65.DragDrop += new DragEventHandler(Button65_DragDrop);
            button66.DragDrop += new DragEventHandler(Button66_DragDrop);
            button67.DragDrop += new DragEventHandler(Button67_DragDrop);
            button68.DragDrop += new DragEventHandler(Button68_DragDrop);
            button69.DragDrop += new DragEventHandler(Button69_DragDrop);
            button70.DragDrop += new DragEventHandler(Button70_DragDrop);

            button1.MouseClick += new MouseEventHandler(Button1_MouseClick);
            button2.MouseClick += new MouseEventHandler(Button2_MouseClick);
            button3.MouseClick += new MouseEventHandler(Button3_MouseClick);
            button4.MouseClick += new MouseEventHandler(Button4_MouseClick);
            button5.MouseClick += new MouseEventHandler(Button5_MouseClick);
            button6.MouseClick += new MouseEventHandler(Button6_MouseClick);
            button7.MouseClick += new MouseEventHandler(Button7_MouseClick);
            button8.MouseClick += new MouseEventHandler(Button8_MouseClick);
            button9.MouseClick += new MouseEventHandler(Button9_MouseClick);
            button10.MouseClick += new MouseEventHandler(Button10_MouseClick);
            button11.MouseClick += new MouseEventHandler(Button11_MouseClick);
            button12.MouseClick += new MouseEventHandler(Button12_MouseClick);
            button13.MouseClick += new MouseEventHandler(Button13_MouseClick);
            button14.MouseClick += new MouseEventHandler(Button14_MouseClick);
            button15.MouseClick += new MouseEventHandler(Button15_MouseClick);
            button16.MouseClick += new MouseEventHandler(Button16_MouseClick);
            button17.MouseClick += new MouseEventHandler(Button17_MouseClick);
            button18.MouseClick += new MouseEventHandler(Button18_MouseClick);
            button19.MouseClick += new MouseEventHandler(Button19_MouseClick);
            button20.MouseClick += new MouseEventHandler(Button20_MouseClick);
            button21.MouseClick += new MouseEventHandler(Button21_MouseClick);
            button22.MouseClick += new MouseEventHandler(Button22_MouseClick);
            button23.MouseClick += new MouseEventHandler(Button23_MouseClick);
            button24.MouseClick += new MouseEventHandler(Button24_MouseClick);
            button25.MouseClick += new MouseEventHandler(Button25_MouseClick);
            button26.MouseClick += new MouseEventHandler(Button26_MouseClick);
            button27.MouseClick += new MouseEventHandler(Button27_MouseClick);
            button28.MouseClick += new MouseEventHandler(Button28_MouseClick);
            button29.MouseClick += new MouseEventHandler(Button29_MouseClick);
            button30.MouseClick += new MouseEventHandler(Button30_MouseClick);
            button31.MouseClick += new MouseEventHandler(Button31_MouseClick);
            button32.MouseClick += new MouseEventHandler(Button32_MouseClick);
            button33.MouseClick += new MouseEventHandler(Button33_MouseClick);
            button34.MouseClick += new MouseEventHandler(Button34_MouseClick);
            button35.MouseClick += new MouseEventHandler(Button35_MouseClick);
            button36.MouseClick += new MouseEventHandler(Button36_MouseClick);
            button37.MouseClick += new MouseEventHandler(Button37_MouseClick);
            button38.MouseClick += new MouseEventHandler(Button38_MouseClick);
            button39.MouseClick += new MouseEventHandler(Button39_MouseClick);
            button40.MouseClick += new MouseEventHandler(Button40_MouseClick);
            button41.MouseClick += new MouseEventHandler(Button41_MouseClick);
            button42.MouseClick += new MouseEventHandler(Button42_MouseClick);
            button43.MouseClick += new MouseEventHandler(Button43_MouseClick);
            button44.MouseClick += new MouseEventHandler(Button44_MouseClick);
            button45.MouseClick += new MouseEventHandler(Button45_MouseClick);
            button46.MouseClick += new MouseEventHandler(Button46_MouseClick);
            button47.MouseClick += new MouseEventHandler(Button47_MouseClick);
            button48.MouseClick += new MouseEventHandler(Button48_MouseClick);
            button49.MouseClick += new MouseEventHandler(Button49_MouseClick);
            button50.MouseClick += new MouseEventHandler(Button50_MouseClick);
            button51.MouseClick += new MouseEventHandler(Button51_MouseClick);
            button52.MouseClick += new MouseEventHandler(Button52_MouseClick);
            button53.MouseClick += new MouseEventHandler(Button53_MouseClick);
            button54.MouseClick += new MouseEventHandler(Button54_MouseClick);
            button55.MouseClick += new MouseEventHandler(Button55_MouseClick);
            button56.MouseClick += new MouseEventHandler(Button56_MouseClick);
            button57.MouseClick += new MouseEventHandler(Button57_MouseClick);
            button58.MouseClick += new MouseEventHandler(Button58_MouseClick);
            button59.MouseClick += new MouseEventHandler(Button59_MouseClick);
            button60.MouseClick += new MouseEventHandler(Button60_MouseClick);
            button61.MouseClick += new MouseEventHandler(Button61_MouseClick);
            button62.MouseClick += new MouseEventHandler(Button62_MouseClick);
            button63.MouseClick += new MouseEventHandler(Button63_MouseClick);
            button64.MouseClick += new MouseEventHandler(Button64_MouseClick);
            button65.MouseClick += new MouseEventHandler(Button65_MouseClick);
            button66.MouseClick += new MouseEventHandler(Button66_MouseClick);
            button67.MouseClick += new MouseEventHandler(Button67_MouseClick);
            button68.MouseClick += new MouseEventHandler(Button68_MouseClick);
            button69.MouseClick += new MouseEventHandler(Button69_MouseClick);
            button70.MouseClick += new MouseEventHandler(Button70_MouseClick);
        }
    }
}
