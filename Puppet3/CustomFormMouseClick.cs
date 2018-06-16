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
        private static string initialText = "ここにファイルをドロップ";

        private void Button_MouseClick(int pictureNumber)
        {
            PictureBox pictureBox = pictureBoxes[pictureNumber];
            Button button = pictureButtons[pictureNumber];
            string file;
            if (pictureNumber < 40)
            {
                file = CustomPictures.FullPath[pictureNumber];
            }
            else
            {
                file = CustomBackground.FullPath[pictureNumber - 40];
            }
            

            if (pictureBox.Image != null)
            {
                pictureBox.Visible = false;
                pictureBox.Image.Dispose();
                try
                {
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                button.Text = initialText;
            }
        }

        private void Button_MouseClickSound(int soundNumber)
        {
            Button button = soundButtons[soundNumber];
            Button playButton = soundPlayButtons[soundNumber];
            TrackBar trackBar = soundTrackBars[soundNumber];
            SoundPlayer soundPlayer = soundPlayers[soundNumber];
            string file = CustomSounds.FullPath[soundNumber];
            if (soundPlayer.waveOut != null)
            {
                soundPlayer.waveOut.Dispose();
                soundPlayer.reader.Dispose();
                try
                {
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                button.Text = initialText;
                playButton.Enabled = false;
                trackBar.Value = 50;
                trackBar.Enabled = false;
            }
        }

        private void Button_MouseClickPlaySound(int soundNumber, int volumeLevel)
        {
            soundPlayers[soundNumber].Play(volumeLevel);
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(0);
        }

        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(1);
        }

        private void Button3_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(2);
        }

        private void Button4_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(3);
        }

        private void Button5_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(0);
        }

        private void Button6_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel1;
            Button_MouseClickPlaySound(0, volumeLevel);
        }

        private void Button7_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(4);
        }

        private void Button8_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(5);
        }

        private void Button9_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(6);
        }

        private void Button10_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(7);
        }

        private void Button11_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(1);
        }

        private void Button12_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel2;
            Button_MouseClickPlaySound(1, volumeLevel);
        }

        private void Button13_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(8);
        }

        private void Button14_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(9);
        }

        private void Button15_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(10);
        }

        private void Button16_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(11);
        }

        private void Button17_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(2);
        }

        private void Button18_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel3;
            Button_MouseClickPlaySound(2, volumeLevel);
        }

        private void Button19_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(12);
        }

        private void Button20_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(13);
        }

        private void Button21_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(14);
        }

        private void Button22_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(15);
        }

        private void Button23_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(3);
        }

        private void Button24_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel4;
            Button_MouseClickPlaySound(3, volumeLevel);
        }

        private void Button25_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(16);
        }

        private void Button26_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(17);
        }

        private void Button27_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(18);
        }

        private void Button28_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(19);
        }

        private void Button29_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(4);
        }

        private void Button30_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel5;
            Button_MouseClickPlaySound(4, volumeLevel);
        }

        private void Button31_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(20);
        }

        private void Button32_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(21);
        }

        private void Button33_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(22);
        }

        private void Button34_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(23);
        }

        private void Button35_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(5);
        }

        private void Button36_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel6;
            Button_MouseClickPlaySound(5, volumeLevel);
        }

        private void Button37_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(24);
        }

        private void Button38_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(25);
        }

        private void Button39_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(26);
        }

        private void Button40_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(27);
        }

        private void Button41_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(6);
        }

        private void Button42_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel7;
            Button_MouseClickPlaySound(6, volumeLevel);
        }

        private void Button43_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(28);
        }

        private void Button44_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(29);
        }

        private void Button45_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(30);
        }

        private void Button46_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(31);
        }

        private void Button47_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(7);
        }

        private void Button48_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel8;
            Button_MouseClickPlaySound(7, volumeLevel);
        }

        private void Button49_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(32);
        }

        private void Button50_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(33);
        }

        private void Button51_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(34);
        }

        private void Button52_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(35);
        }

        private void Button53_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(8);
        }

        private void Button54_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel9;
            Button_MouseClickPlaySound(8, volumeLevel);
        }

        private void Button55_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(36);
        }

        private void Button56_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(37);
        }

        private void Button57_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(38);
        }

        private void Button58_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(39);
        }

        private void Button59_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClickSound(9);
        }

        private void Button60_MouseClick(object sender, MouseEventArgs e)
        {
            int volumeLevel = Properties.Settings.Default.SoundVolumeLevel0;
            Button_MouseClickPlaySound(9, volumeLevel);
        }

        // Button61 to Button70 for background
        private void Button61_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(40);
        }

        private void Button62_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(41);
        }

        private void Button63_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(42);
        }

        private void Button64_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(43);
        }

        private void Button65_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(44);
        }

        private void Button66_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(45);
        }

        private void Button67_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(46);
        }

        private void Button68_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(47);
        }

        private void Button69_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(48);
        }

        private void Button70_MouseClick(object sender, MouseEventArgs e)
        {
            Button_MouseClick(49);
        }

    }
}
