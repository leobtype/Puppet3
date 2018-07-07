using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Puppet3
{
    public partial class CustomForm : Form
    {
        private static List<SoundPlayer> soundPlayers = new List<SoundPlayer>();

        public CustomForm(SoundPlayer sound)
        {
            CreateSoundPlayers();
            InitializeComponent();
            PictureBoxesInit();
            PictureButtonsInit();
            SoundButtonsInit();
            SoundPlayButtonsInit();
            SoundTrackBarsInit();
            SetEvents();
        }

        private void CreateSoundPlayers()
        {
            for (int i = 0; i < 10; i++)
            {
                soundPlayers.Add(new SoundPlayer());
                if (File.Exists(CustomSounds.FullPath[i])) soundPlayers[i].Init(CustomSounds.FullPath[i]);
            }
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
                e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void InitializePictureBox(PictureBox pictureBox, string file)
        {
            Bitmap bitmap = new Bitmap(file);
            float scale = Math.Max((float)pictureBox.Width / bitmap.Width, (float)pictureBox.Height / bitmap.Height);
            pictureBox.BackgroundImageLayout = ImageLayout.None;
            //pictureBox.Location = new Point(0, 0);
            //pictureBox.Margin = new Padding(0);
            pictureBox.Size = new Size((int)(bitmap.Size.Width * scale), (int)(bitmap.Size.Height * scale));
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox.TabIndex = 0;
            //pictureBox.TabStop = false;
            pictureBox.Image = bitmap;
            pictureBox.Visible = true;
        }

        private void InitializeButtonText(Button button)
        {
            button.Text = resetText;
        }

        private static string resetText = "リセット";

        private void CustomForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 40; i++)
            {
                if (File.Exists(CustomPictures.FullPath[i]))
                {
                    InitializePictureBox(pictureBoxes[i], CustomPictures.FullPath[i]);
                    InitializeButtonText(pictureButtons[i]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (File.Exists(CustomBackground.FullPath[i]))
                {
                    InitializePictureBox(pictureBoxes[i+40], CustomBackground.FullPath[i]);
                    InitializeButtonText(pictureButtons[i+40]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (File.Exists(CustomSounds.FullPath[i]))
                {
                    soundPlayButtons[i].Enabled = true;
                    soundTrackBars[i].Enabled = true;
                }
            }
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            foreach(PictureBox pictureBox in pictureBoxes)
            {
                if (pictureBox.Image != null) pictureBox.Image.Dispose();
            }
            foreach(SoundPlayer soundPlayer in soundPlayers)
            {
                if(soundPlayer.waveOut != null) soundPlayer.waveOut.Dispose();
                if (soundPlayer.reader != null) soundPlayer.reader.Dispose();
                if (soundPlayer != null) soundPlayer.Dispose();
            }
            soundPlayers.RemoveRange(0, soundPlayers.Count);
            Dispose();
        }
    }
}
