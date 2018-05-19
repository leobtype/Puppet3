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
    public partial class ConfigForm : Form
    {
        private MascotForm mascotForm;
        private Microphone microphone;
        public ConfigForm(MascotForm form, Microphone mic)
        {
            mascotForm = form;
            microphone = mic;
            InitializeComponent();
            SetEvents();
            SetMicrophoneDeviceList();
            IndicateMicrophoneVolumeLevel();
        }

        private void SetMicrophoneDeviceList()
        {
            List<string> microphoneProductNames = new List<string>();
            if (microphone.DeviceCount == 0)
            {
                microphoneProductNames.Add("マイクロフォンなし");
            }
            else
            {
                for (int i = 0; i < microphone.DeviceCount; i++)
                {
                    microphoneProductNames.Add(microphone.deviceProductName(i));
                }
            }
            string[] products = microphoneProductNames.ToArray();
            comboBox1.Items.AddRange(products);
            comboBox1.SelectedIndex = microphone.DeviceNumber;
        }

        private void IndicateMicrophoneVolumeLevel()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1;
            timer.Start();
        }

        private void TimerEventProcessor(object obj, EventArgs e)
        {
            progressBar1.Value = microphone.VolumeLevel;
        }
    }
}
