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
        private Microphone2 microphone;
        private ApplicationSound applicationSound;

        public ConfigForm(MascotForm form, Microphone2 mic, ApplicationSound appSound)
        {
            mascotForm = form;
            microphone = mic;
            applicationSound = appSound;
            InitializeComponent();
            InitializeRadioButton();
            SetEvents();
            SetMicrophoneDeviceList();
            SetApplicationSoundNameList();
            IndicateMicrophoneVolumeLevel();
        }

        private void InitializeRadioButton()
        {
            string soundSource = Properties.Settings.Default.SoundSource;
            switch (soundSource)
            {
                case "Microphone":
                    radioButton1.Checked = true;
                    comboBox1.Enabled = true;
                    radioButton2.Checked = false;
                    comboBox2.Enabled = false;
                    break;
                case "Application":
                    radioButton1.Checked = false;
                    comboBox1.Enabled = false;
                    radioButton2.Checked = true;
                    comboBox2.Enabled = true;
                    break;
                default:
                    radioButton1.Checked = false;
                    comboBox1.Enabled = false;
                    radioButton2.Checked = false;
                    comboBox2.Enabled = false;
                    break;
            }
        }

        private void SetApplicationSoundNameList()
        {
            List<List<string>> applicationInfoList = applicationSound.GetApplicationInfo();
            List<string> info = new List<string>();
            int index = 0;
            for (int i = 0; i < applicationInfoList.Count; i++)
            {
                if (applicationInfoList[i][3] == true.ToString())
                {
                    info.Add("[" + applicationInfoList[i][2].ToString() + "] "+ "SystemSound ");
                }
                else if(applicationInfoList[i][0] == "")
                {
                    info.Add("[" + applicationInfoList[i][2].ToString() + "] " + applicationInfoList[i][1]);
                } else
                {
                    info.Add("[" + applicationInfoList[i][2].ToString() + "] " + applicationInfoList[i][0]);
                }
                if (applicationSound.ApplicationPid != null)
                {
                    if (applicationSound.ApplicationPid == applicationInfoList[i][2].ToString())
                    {
                        index = i;
                    }
                }
            }
            string[] apps = info.ToArray();
            comboBox2.Items.AddRange(apps);
            comboBox2.SelectedIndex = index;
        }

        private void SetMicrophoneDeviceList()
        {
            List<List<string>> microphoneInfoList = microphone.GetMicrophoneInfo();
            List<string> info = new List<string>();
            int index = 0;
            for (int i = 0; i < microphoneInfoList.Count; i++)
            {
                info.Add( microphoneInfoList[i][1]);
                if (microphone.MicrophoneId != null)
                {
                    if (microphone.MicrophoneId == microphoneInfoList[i][0])
                    {
                        index = i;
                    }
                }
            }
            string[] mics = info.ToArray();
            comboBox1.Items.AddRange(mics);
            comboBox1.SelectedIndex = index;
        }

        //private void SetMicrophoneDeviceList()
        //{
        //    List<string> microphoneProductNames = new List<string>();
        //    if (microphone.DeviceCount == 0)
        //    {
        //        microphoneProductNames.Add("マイクロフォンなし");
        //    }
        //    else
        //    {
        //        for (int i = 0; i < microphone.DeviceCount; i++)
        //        {
        //            microphoneProductNames.Add(microphone.deviceProductName(i));
        //        }
        //    }
        //    string[] products = microphoneProductNames.ToArray();
        //    comboBox1.Items.AddRange(products);
        //    comboBox1.SelectedIndex = microphone.DeviceNumber;
        //}

        private void IndicateMicrophoneVolumeLevel()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1;
            timer.Start();
        }

        private void TimerEventProcessor(object obj, EventArgs e)
        {
            switch (Properties.Settings.Default.SoundSource)
            {
                case "Microphone":
                    //progressBar1.Value = microphone.VolumeLevel;
                    progressBar1.Value = (int)microphone.GetMicrophoneVolumeLevel();
                    break;
                case "Application":
                    progressBar1.Value = (int)applicationSound.GetApplicationVolumeLevel();
                    break;
                default:
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Properties.Settings.Default.SoundSource = "Microphone";
                comboBox1.Enabled = true;
                radioButton2.Checked = false;
                comboBox2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Properties.Settings.Default.SoundSource = "Application";
                comboBox2.Enabled = true;
                radioButton1.Checked = false;
                comboBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var mic in microphone.GetMicrophoneInfo())
            {
                if (mic[1] == comboBox1.SelectedText)
                {
                    Properties.Settings.Default.MicrophoneDeviceId = mic[0];
                    break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationSound.ApplicationPid = comboBox2.SelectedItem.ToString().Split('[')[1].Split(']')[0];
        }
    }
}
