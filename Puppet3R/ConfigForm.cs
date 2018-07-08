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
        private Timer timer;

        public ConfigForm(MascotForm form, Microphone2 mic, ApplicationSound appSound)
        {
            mascotForm = form;
            microphone = mic;
            applicationSound = appSound;
            applicationSound.Refresh();
            InitializeComponent();
            InitializeRadioButton();
            SetEvents();
            SetMicrophoneDeviceList();
            SetApplicationSoundNameList("Render");
            SetApplicationSoundNameList("Capture");
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
                    radioButton3.Checked = false;
                    comboBox3.Enabled = false;
                    break;
                case "ApplicationRender":
                    radioButton1.Checked = false;
                    comboBox1.Enabled = false;
                    radioButton2.Checked = true;
                    comboBox2.Enabled = true;
                    radioButton3.Checked = false;
                    comboBox3.Enabled = false;
                    break;
                case "ApplicationCapture":
                    radioButton1.Checked = false;
                    comboBox1.Enabled = false;
                    radioButton2.Checked = false;
                    comboBox2.Enabled = false;
                    radioButton3.Checked = true;
                    comboBox3.Enabled = true;
                    break;
                default:
                    radioButton1.Checked = false;
                    comboBox1.Enabled = false;
                    radioButton2.Checked = false;
                    comboBox2.Enabled = false;
                    radioButton3.Checked = false;
                    comboBox3.Enabled = false;
                    break;
            }
        }

        private void SetApplicationSoundNameList(string dataflow)
        {
            List<List<string>> applicationInfoList = applicationSound.GetApplicationInfo(dataflow);
            List<string> info = new List<string>();
            int index = 0;
            for (int i = 0; i < applicationInfoList.Count; i++)
            {
                if (applicationInfoList[i][1] == "#" && applicationInfoList[i][3] != true.ToString()) continue;
                if (applicationInfoList[i][3] == true.ToString())
                {
                    info.Add("[" + applicationInfoList[i][2].ToString() + "] " + "SystemSound ");
                }
                else if (applicationInfoList[i][0] == "")
                {
                    info.Add("[" + applicationInfoList[i][2].ToString() + "] " + applicationInfoList[i][1]);
                }
                else
                {
                    info.Add("[" + applicationInfoList[i][2].ToString() + "] " + applicationInfoList[i][0]);
                }
                switch (dataflow)
                {
                    case "Render":
                        if (applicationSound.ApplicationRenderPid != null)
                        {
                            if (applicationSound.ApplicationRenderPid == applicationInfoList[i][2].ToString())
                            {
                                index = i;
                            }
                        }
                        break;
                    case "Capture":
                        if (applicationSound.ApplicationCapturePid != null)
                        {
                            if (applicationSound.ApplicationCapturePid == applicationInfoList[i][2].ToString())
                            {
                                index = i;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            string[] apps = info.ToArray();
            switch (dataflow)
            {
                case "Render":
                    comboBox2.Items.AddRange(apps);
                    if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = index;
                    break;
                case "Capture":
                    comboBox3.Items.AddRange(apps);
                    if (comboBox3.Items.Count > 0) comboBox3.SelectedIndex = index;
                    break;
                default:
                    break;
            }
        }

        private void SetMicrophoneDeviceList()
        {
            List<List<string>> microphoneInfoList = microphone.GetMicrophoneInfo();
            List<string> info = new List<string>();
            int index = 0;
            for (int i = 0; i < microphoneInfoList.Count; i++)
            {
                info.Add(microphoneInfoList[i][1]);
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
            try
            {
                comboBox1.SelectedIndex = index;
            }
            catch
            {
                // no available recording device
            }
        }

        private void IndicateMicrophoneVolumeLevel()
        {
            timer = new Timer();
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
                case "ApplicationRender":
                    progressBar1.Value = (int)applicationSound.GetApplicationVolumeLevel("Render");
                    break;
                case "ApplicationCapture":
                    progressBar1.Value = (int)applicationSound.GetApplicationVolumeLevel("Capture");
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
                radioButton3.Checked = false;
                comboBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Properties.Settings.Default.SoundSource = "ApplicationRender";
                comboBox2.Enabled = true;
                radioButton1.Checked = false;
                comboBox1.Enabled = false;
                radioButton3.Checked = false;
                comboBox3.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Properties.Settings.Default.SoundSource = "ApplicationCapture";
                comboBox3.Enabled = true;
                radioButton1.Checked = false;
                comboBox1.Enabled = false;
                radioButton2.Checked = false;
                comboBox2.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var mic in microphone.GetMicrophoneInfo())
            {
                if (mic[1] == comboBox1.Text)
                {
                    Properties.Settings.Default.MicrophoneDeviceId = mic[0];
                    microphone.MicrophoneId = mic[0];
                    break;
                }
            }
            IndicateMicrophoneVolumeLevel();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationSound.ApplicationRenderPid = comboBox2.SelectedItem.ToString().Split('[')[1].Split(']')[0];
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationSound.ApplicationCapturePid = comboBox3.SelectedItem.ToString().Split('[')[1].Split(']')[0];
        }
    }
}
