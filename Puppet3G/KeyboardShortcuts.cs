using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Puppet3
{
    public partial class MascotForm : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.D1))
            {
                Alt_Number(new int[] { 0, 1, 2, 3 }, 0, 0);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D2))
            {
                Alt_Number(new int[] { 4, 5, 6, 7 }, 1, 1);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D3))
            {
                Alt_Number(new int[] { 8, 9, 10, 11 }, 2, 2);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D4))
            {
                Alt_Number(new int[] { 12, 13, 14, 15 }, 3, 3);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D5))
            {
                Alt_Number(new int[] { 16, 17, 18, 19 }, 4, 4);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D6))
            {
                Alt_Number(new int[] { 20, 21, 22, 23 }, 5, 5);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D7))
            {
                Alt_Number(new int[] { 24, 25, 26, 27 }, 6, 6);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D8))
            {
                Alt_Number(new int[] { 28, 29, 30, 31 }, 7, 7);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D9))
            {
                Alt_Number(new int[] { 32, 33, 34, 35 }, 8, 8);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D0))
            {
                Alt_Number(new int[] { 36, 37, 38, 39 }, 9, 9);
                return true;
            }
            if (keyData == (Keys.Alt | Keys.OemMinus))
            {
                DrawDefaultMascot();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DrawDefaultMascot()
        {
            SuspendLayout();
            pictureBoxes[0].Image.Dispose();
            pictureBoxes[1].Image.Dispose();
            pictureBoxes[2].Image.Dispose();
            pictureBoxes[3].Image.Dispose();
            pictureBoxes[4].Image.Dispose();
            InitializePictureBox(pictureBoxes[0], new Bitmap(Properties.Resources.default0));
            InitializePictureBox(pictureBoxes[1], new Bitmap(Properties.Resources.default1));
            InitializePictureBox(pictureBoxes[2], new Bitmap(Properties.Resources.default2));
            InitializePictureBox(pictureBoxes[3], new Bitmap(Properties.Resources.default3));
            InitializePictureBox(pictureBoxes[4], new Bitmap(Properties.Resources.default5));
            pictureBoxes[4].Visible = true;
            pictureBoxes[4].Parent = this;
            pictureBoxes[0].Parent = pictureBoxes[4];
            pictureBoxes[1].Parent = pictureBoxes[4];
            pictureBoxes[2].Parent = pictureBoxes[4];
            pictureBoxes[3].Parent = pictureBoxes[4];
            ClientSize = new Size(pictureBoxes[0].Size.Width, pictureBoxes[0].Size.Height);
            ResumeLayout(false);
        }

        private void DrawPictures(int [] pictureNums, int backgroundNum)
        {
            SuspendLayout();
            int i = 0;
            foreach (int p in pictureNums)
            {
                pictureBoxes[i].Image.Dispose();
                {
                    File.Copy(CustomPictures.FullPath[p], CustomPictures.Current[i], true);
                    InitializePictureBox(pictureBoxes[i], new Bitmap(CustomPictures.Current[i]));
                }
                i++;
            }
            ClientSize = new Size(pictureBoxes[0].Size.Width, pictureBoxes[0].Size.Height);
            if (File.Exists(CustomBackground.FullPath[backgroundNum]))
            {
                pictureBoxes[4].Image.Dispose();
                File.Copy(CustomBackground.FullPath[backgroundNum], CustomBackground.Current, true);
                InitializePictureBox(pictureBoxes[4], new Bitmap(CustomBackground.Current));
            }
            else
            {
                pictureBoxes[4].Image.Dispose();
                File.Delete(CustomBackground.Current);
                InitializePictureBox(pictureBoxes[4], new Bitmap(Properties.Resources.spacer));
                pictureBoxes[4].Size = pictureBoxes[0].Size;
            }
            for (int j = 0; j < 4; j++)
            {
                pictureBoxes[j].Parent = pictureBoxes[4];
            }
            pictureBoxes[4].Visible = true;
            ResumeLayout(false);
        }

        private void PlaySound(int soundNum)
        {
            if (File.Exists(CustomSounds.FullPath[soundNum]))
            {
                List<int> volumeLevels = new List<int>()
                    {
                        Properties.Settings.Default.SoundVolumeLevel1,
                        Properties.Settings.Default.SoundVolumeLevel2,
                        Properties.Settings.Default.SoundVolumeLevel3,
                        Properties.Settings.Default.SoundVolumeLevel4,
                        Properties.Settings.Default.SoundVolumeLevel5,
                        Properties.Settings.Default.SoundVolumeLevel6,
                        Properties.Settings.Default.SoundVolumeLevel7,
                        Properties.Settings.Default.SoundVolumeLevel8,
                        Properties.Settings.Default.SoundVolumeLevel9,
                        Properties.Settings.Default.SoundVolumeLevel0
                    };
                if (soundPlayer.waveOut != null) soundPlayer.waveOut.Dispose();
                if (soundPlayer.reader != null) soundPlayer.reader.Dispose();
                File.Copy(CustomSounds.FullPath[soundNum], CustomSounds.Current, true);
                soundPlayer.Init(CustomSounds.Current);
                soundPlayer.Play(volumeLevels[soundNum]);
            }
            else
            {
                if (File.Exists(CustomSounds.Current))
                {
                    if (soundPlayer.waveOut != null) soundPlayer.waveOut.Dispose();
                    if (soundPlayer.reader != null) soundPlayer.reader.Dispose();
                    File.Delete(CustomSounds.Current);
                }
            }
        }

        private async void Alt_Number(int[] pictureNums, int backgroundNum, int soundNum)
        {
            bool customPicturesExists = true;
            foreach (int i in pictureNums)
            {
                if (File.Exists(CustomPictures.FullPath[i]) == false)
                {
                    customPicturesExists = false;
                }
            }
            if (customPicturesExists)
            {
                DrawPictures(pictureNums, backgroundNum);
                await Task.Run(() => PlaySound(soundNum));
            }
        }
    }
}
