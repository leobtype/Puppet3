using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet3
{
    public partial class MascotForm : Form
    {
        private static Microphone2 microphone;
        private static SoundPlayer soundPlayer;
        private static ApplicationSound applicationSound;

        public MascotForm(Microphone2 mic, SoundPlayer sound, ApplicationSound appSound)
        {
            microphone = mic;
            soundPlayer = sound;
            applicationSound = appSound;
            InitializeComponent();
            Preprocess();
            Motion();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm(this, microphone, applicationSound);
            try
            {

                configForm.ShowDialog(this);
            }
            finally
            {
                configForm.Dispose();
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            microphone.Dispose();
            Close();
        }

        public static void ResizePictureBoxes(int scale)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                ResizePictureBox(pictureBox, scale);
            }
        }

        private static void ResizePictureBox(PictureBox pictureBox, int scaleVal)
        {
            float scale = scaleVal / 100.0f;
            int width = pictureBox.Image.Width;
            int height = pictureBox.Image.Height;
            pictureBox.Size = new Size((int)(width * scale), (int)(height * scale));
        }

        public static void ResetTimer(int interval)
        {
            timer.Stop();
            timer.Interval = interval;
            timer.Start();
        }

        public static void ResetFrequency(int frequency)
        {
            blinkFrequency = frequency;
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomForm customForm = new CustomForm(soundPlayer);
            try
            {
                customForm.ShowDialog(this);
            }
            finally
            {
                customForm.Dispose();
            }
        }

        private void aboutPuppet3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            try
            {
                aboutForm.ShowDialog(this);
            }
            finally
            {
                aboutForm.Dispose();
            }
        }
    }
}
