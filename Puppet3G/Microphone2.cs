using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace Puppet3
{
    public class Microphone2
    {
        public string MicrophoneId { get; set; }
        public int VolumeLevelThreshold { get; set; }
        private WaveInEvent waveInStream;

        public Microphone2()
        {
            if (Properties.Settings.Default.MicrophoneDeviceId == "")
            {
                if (GetMicrophoneInfo().Count > 0)
                {
                    MicrophoneId = GetMicrophoneInfo()[0][0];
                }
                else
                {
                    MicrophoneId = "";
                }

            }
            else
            {
                MicrophoneId = Properties.Settings.Default.MicrophoneDeviceId;
            }
            Properties.Settings.Default.MicrophoneDeviceId = MicrophoneId;
            VolumeLevelThreshold = Properties.Settings.Default.MicrophoneVolumeLevelThreshold;
            waveInStream = new WaveInEvent();
            waveInStream.WaveFormat = new WaveFormat(44100, 1);
            Start();
        }

        public List<List<string>> GetMicrophoneInfo()
        {
            /*  return:
             *      MMDevice.ID
             *      MMDevice.FriendlyName
             *      MMDevice.DeviceFriendlyName
             */
            List<List<string>> microphoneInfo = new List<List<string>>();
            MMDeviceEnumerator deviceEnumerator = (MMDeviceEnumerator)(new MMDeviceEnumerator());
            foreach (MMDevice microphone in deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                microphoneInfo.Add(new List<string> {
                    microphone.ID,
                    microphone.FriendlyName,
                    microphone.DeviceFriendlyName
                });
                microphone.Dispose();
            }
            deviceEnumerator.Dispose();
            return microphoneInfo;
        }

        public float GetMicrophoneVolumeLevel()
        {
            float volume = 0.0f;
            MMDeviceEnumerator deviceEnumerator = (MMDeviceEnumerator)(new MMDeviceEnumerator());
            foreach (MMDevice microphone in deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                if (microphone.ID == this.MicrophoneId)
                {
                    volume = microphone.AudioMeterInformation.MasterPeakValue;
                    microphone.Dispose();
                    break;
                }
                else
                {
                    microphone.Dispose();
                }
            }
            deviceEnumerator.Dispose();
            return volume * 100;
        }

        public void Start()
        {
            try
            {
                waveInStream.StartRecording();
            }
            catch
            {
                // no available recording device
            }

        }
        public void Stop()
        {
            waveInStream.StopRecording();
        }

        public void Reset()
        {
            waveInStream.StopRecording();
            waveInStream.Dispose();
            waveInStream = new WaveInEvent();
            waveInStream.WaveFormat = new WaveFormat(44100, 1);
            waveInStream.StartRecording();
        }

        public void Dispose()
        {
            Stop();
            waveInStream.Dispose();
        }
    }

}
