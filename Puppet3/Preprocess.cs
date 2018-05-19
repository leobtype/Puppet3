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
        static List<PictureBox> pictureBoxes;

        private void Preprocess()
        {
            this.SuspendLayout();
            SetTransparency();
            List<Bitmap> currentBitmaps = SetupBitmaps();
            pictureBoxes = CreatePictureBoxes(currentBitmaps);
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                Controls.Add(pictureBox);
                SetMouseEvent(pictureBox);
                pictureBox.Visible = false;
            }
            ClientSize = new Size(pictureBoxes[0].Size.Width, pictureBoxes[0].Size.Height);
            pictureBoxes[0].Visible = true;
            SetLocation();
            this.ResumeLayout(false);
        }

        private void SetLocation()
        {
            if (Properties.Settings.Default.LocationInitialized == false)
            {
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int pictureHeight = pictureBoxes[0].Height;
                int pictureWidth = pictureBoxes[0].Width;
                Point location = new Point(screenWidth - pictureWidth, screenHeight - pictureHeight);
                this.Location = location;
                Properties.Settings.Default.Location = location;
                Properties.Settings.Default.LocationInitialized = true;
            }
        }

        private void SetTransparency()
        {
            if (Properties.Settings.Default.Transparency == true)
            {
                TransparencyKey = Properties.Settings.Default.MascotBackColor;
            }
        }

        private List<Bitmap> SetupBitmaps()
        {
            List<Bitmap> currentBitmaps = new List<Bitmap>();
            bool currentCustomExists = true;
            foreach (string picture in CustomPictures.Current)
            {
                if (File.Exists(picture) == false)
                {
                    currentCustomExists = false;
                    break;
                }
            }
            if (currentCustomExists)
            {
                foreach(string picture in CustomPictures.Current)
                {
                    currentBitmaps.Add(new Bitmap(picture));
                }
            }
            else
            {
                currentBitmaps.Add(Properties.Resources.default0);
                currentBitmaps.Add(Properties.Resources.default1);
                currentBitmaps.Add(Properties.Resources.default2);
                currentBitmaps.Add(Properties.Resources.default3);
            }
            return currentBitmaps;
        }

        private List<PictureBox> CreatePictureBoxes(List<Bitmap> currentBitmaps) {
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            foreach (Bitmap bitmap in currentBitmaps)
            {
                PictureBox pictureBox = new PictureBox();
                InitializePictureBox(pictureBox, bitmap);
                pictureBoxes.Add(pictureBox);
            }
            return pictureBoxes;
        }

        private void InitializePictureBox(PictureBox pictureBox, Bitmap bitmap)
        {
            float scale = (float)Properties.Settings.Default.PictureScale / 100.0f;
            pictureBox.BackgroundImageLayout = ImageLayout.None;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(0);
            pictureBox.Size = new Size((int)(bitmap.Size.Width * scale), (int)(bitmap.Size.Height * scale));
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Image = bitmap;
            pictureBox.Visible = false;
        }
    }
}
