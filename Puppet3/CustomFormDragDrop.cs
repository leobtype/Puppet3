using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;

namespace Puppet3
{
    public partial class CustomForm : Form
    {
        private bool ValidBitmap(string file)
        {
            try
            {
                Bitmap bitmap = new Bitmap(file);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidMp3(string file, SoundPlayer soundPlayer)
        {
            try
            {
                soundPlayer.Init(file);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Button_DragDrop(int pictureNumber, DragEventArgs e)
        {
            PictureBox pictureBox = pictureBoxes[pictureNumber];
            Button button = pictureButtons[pictureNumber];
            string file = CustomPictures.FullPath[pictureNumber];
            string[] fromFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (ValidBitmap(fromFiles[0]))
            {
                if (pictureBox.Image != null) pictureBox.Image.Dispose();
                File.Copy(fromFiles[0], file, true);
                InitializePictureBox(pictureBox, file);
                button.Text = resetText;
            }
        }

        private void Button_DragDropSound(int soundNumber, DragEventArgs e)
        {
            Button button = soundButtons[soundNumber];
            Button playButton = soundPlayButtons[soundNumber];
            TrackBar trackBar = soundTrackBars[soundNumber];
            SoundPlayer soundPlayer = soundPlayers[soundNumber];
            string file = CustomSounds.FullPath[soundNumber];
            string[] fromFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (ValidMp3(fromFiles[0], new SoundPlayer()))
            {
                if (soundPlayer.waveOut != null)
                {
                    soundPlayer.waveOut.Dispose();
                    soundPlayer.reader.Dispose();
                    soundPlayer.reader.Close();
                }
                File.Copy(fromFiles[0], file, true);
                if (soundPlayer.Init(file) == true)
                {
                    playButton.Enabled = true;
                    trackBar.Enabled = true;
                    button.Text = resetText;
                }
                else
                {
                    playButton.Enabled = false;
                    trackBar.Enabled = false;
                    button.Text = initialText;
                }
            }
        }

        private void Button1_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(0, e);
        }

        private void Button2_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(1, e);
        }

        private void Button3_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(2, e);
        }

        private void Button4_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(3, e);
        }

        private void Button5_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(0, e);
        }

        private void Button6_DragDrop(object sender, DragEventArgs e) { }

        private void Button7_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(4, e);
        }

        private void Button8_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(5, e);
        }

        private void Button9_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(6, e);
        }

        private void Button10_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(7, e);
        }

        private void Button11_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(1, e);
        }

        private void Button12_DragDrop(object sender, DragEventArgs e) { }

        private void Button13_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(8, e);
        }

        private void Button14_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(9, e);
        }

        private void Button15_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(10, e);
        }

        private void Button16_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(11, e);
        }

        private void Button17_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(2, e);
        }

        private void Button18_DragDrop(object sender, DragEventArgs e) { }

        private void Button19_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(12, e);
        }

        private void Button20_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(13, e);
        }

        private void Button21_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(14, e);
        }

        private void Button22_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(15, e);
        }

        private void Button23_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(3, e);
        }

        private void Button24_DragDrop(object sender, DragEventArgs e) { }

        private void Button25_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(16, e);
        }

        private void Button26_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(17, e);
        }

        private void Button27_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(18, e);
        }

        private void Button28_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(19, e);
        }

        private void Button29_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(4, e);
        }

        private void Button30_DragDrop(object sender, DragEventArgs e) { }

        private void Button31_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(20, e);
        }

        private void Button32_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(21, e);
        }

        private void Button33_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(22, e);
        }

        private void Button34_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(23, e);
        }

        private void Button35_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(5, e);
        }

        private void Button36_DragDrop(object sender, DragEventArgs e) { }

        private void Button37_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(24, e);
        }

        private void Button38_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(25, e);
        }

        private void Button39_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(26, e);
        }

        private void Button40_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(27, e);
        }

        private void Button41_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(6, e);
        }

        private void Button42_DragDrop(object sender, DragEventArgs e) { }

        private void Button43_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(28, e);
        }

        private void Button44_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(29, e);
        }

        private void Button45_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(30, e);
        }

        private void Button46_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(31, e);
        }

        private void Button47_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(7, e);
        }

        private void Button48_DragDrop(object sender, DragEventArgs e) { }

        private void Button49_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(32, e);
        }

        private void Button50_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(33, e);
        }

        private void Button51_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(34, e);
        }

        private void Button52_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(35, e);
        }

        private void Button53_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(8, e);
        }

        private void Button54_DragDrop(object sender, DragEventArgs e) { }

        private void Button55_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(36, e);
        }

        private void Button56_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(37, e);
        }

        private void Button57_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(38, e);
        }

        private void Button58_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDrop(39, e);
        }

        private void Button59_DragDrop(object sender, DragEventArgs e)
        {
            Button_DragDropSound(9, e);
        }

        private void Button60_DragDrop(object sender, DragEventArgs e) { }
    }
}
