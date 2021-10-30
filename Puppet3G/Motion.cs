using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet3
{
    public partial class MascotForm : Form
    {
        static Timer timer = new Timer();
        static Puppet3.Properties.Settings config = Properties.Settings.Default;
        static int blinkFrequency = config.BlinkFrequency;

        private bool MOUSE_OPEN = false;
        private bool EYES_OPEN = true;
        private DateTime lastTime;

        private void Motion()
        {
            Puppet3.Properties.Settings config = Properties.Settings.Default;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1;
            timer.Start();
        }

        private void TimerEventProcessor(object obj, EventArgs e)
        {
            if (lastTime.AddMilliseconds((double)config.BlinkDuration) > DateTime.Now) return;
            if (Properties.Settings.Default.IsEmoteEnable == true)
            {
                if (JudgeSound2() == true)
                {
                    Alt_Number(new int[] { 36, 37, 38, 39 }, 0, 0);
                }
                else
                {
                    Alt_Number(new int[] { 0, 1, 2, 3 }, 0, 0);
                }
            }

            if (Properties.Settings.Default.MouthOpenWhileSound == true)
            {
                if (JudgeSound() == true)
                {
                    ToggleEyes();
                    MOUSE_OPEN = true;
                }
                else
                {
                    ToggleEyes();
                    MOUSE_OPEN = false;
                }
            }
            else
            {
                if (JudgeSound() == true)
                {
                    ToggleEyes();
                    ToggleMouse();
                }
                else
                {
                    ToggleEyes();
                    MOUSE_OPEN = false;
                }
            }
            ReDraw();
            lastTime = DateTime.Now;
        }

        private void ReDraw()
        {
            SuspendLayout();
            if (!MOUSE_OPEN && EYES_OPEN)
            {
                pictureBoxes[0].Visible = true;
                pictureBoxes[1].Visible = false;
                pictureBoxes[2].Visible = false;
                pictureBoxes[3].Visible = false;
            }
            if (!MOUSE_OPEN && !EYES_OPEN)
            {
                pictureBoxes[1].Visible = true;
                pictureBoxes[0].Visible = false;
                pictureBoxes[2].Visible = false;
                pictureBoxes[3].Visible = false;
            }
            if (MOUSE_OPEN && EYES_OPEN)
            {
                pictureBoxes[2].Visible = true;
                pictureBoxes[0].Visible = false;
                pictureBoxes[1].Visible = false;
                pictureBoxes[3].Visible = false;
            }
            if (MOUSE_OPEN && !EYES_OPEN)
            {
                pictureBoxes[3].Visible = true;
                pictureBoxes[0].Visible = false;
                pictureBoxes[1].Visible = false;
                pictureBoxes[2].Visible = false;
            }
            ResumeLayout(false);
        }

        private static bool JudgeSound()
        {
            switch (Properties.Settings.Default.SoundSource)
            {
                case "Microphone":
                    //return (microphone.VolumeLevel > microphone.VolumeLevelThreshold) ? true : false;
                    return (microphone.GetMicrophoneVolumeLevel() > microphone.VolumeLevelThreshold) ? true : false;
                case "ApplicationRender":
                    return ((int)applicationSound.GetApplicationVolumeLevel("Render") > Properties.Settings.Default.MicrophoneVolumeLevelThreshold) ? true : false;
                case "ApplicationCapture":
                    return ((int)applicationSound.GetApplicationVolumeLevel("Capture") > Properties.Settings.Default.MicrophoneVolumeLevelThreshold) ? true : false;
                default:
                    return false;
            }
        }

        private static bool JudgeSound2()
        {
            switch (Properties.Settings.Default.SoundSource)
            {
                case "Microphone":
                    //return (microphone.VolumeLevel > microphone.VolumeLevelThreshold) ? true : false;
                    return (microphone.GetMicrophoneVolumeLevel() > microphone.VolumeLevelthresholdEmote) ? true : false;
                case "ApplicationRender":
                    return ((int)applicationSound.GetApplicationVolumeLevel("Render") > Properties.Settings.Default.MicrophoneVolumeLevelthresholdEmote) ? true : false;
                case "ApplicationCapture":
                    return ((int)applicationSound.GetApplicationVolumeLevel("Capture") > Properties.Settings.Default.MicrophoneVolumeLevelthresholdEmote) ? true : false;
                default:
                    return false;
            }
        }

        private void ToggleEyes()
        {
            if (EYES_OPEN == true)
            {
                Random random = new Random((int)System.DateTime.Now.Ticks);
                if (random.Next(1000) < blinkFrequency)
                {
                    EYES_OPEN = false;
                }
            }
            else
            {
                EYES_OPEN = true;
            }
        }

        private void ToggleMouse()
        {
            MOUSE_OPEN = MOUSE_OPEN ? false : true;
        }
    }
}
