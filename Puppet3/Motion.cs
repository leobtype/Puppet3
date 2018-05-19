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

        private void Motion()
        {
            Puppet3.Properties.Settings config = Properties.Settings.Default;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = config.BlinkDuration;
            timer.Start();
        }

        private void TimerEventProcessor(object obj, EventArgs e)
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
            ReDraw();
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
            return ( microphone.VolumeLevel > microphone.VolumeLevelThreshold ) ? true : false;
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
