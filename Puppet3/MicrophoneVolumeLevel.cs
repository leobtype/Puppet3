using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Mixer;

namespace Puppet3
{
    public partial class Microphone
    {
        private int volumeLevel = 0;
        public int VolumeLevel
        {
            get { return volumeLevel; }
        }

        private int volumeLevelThreshold = Properties.Settings.Default.MicrophoneVolumeLevelThreshold;
        public int VolumeLevelThreshold
        {
            get { return volumeLevelThreshold; }
            set { volumeLevelThreshold = value;  }
        }

        private void waveInEvent_DataAvailable(object sender, WaveInEventArgs e)
        {
            int bitRate = WaveInEvent.WaveFormat.BitsPerSample;
            switch (WaveInEvent.WaveFormat.BitsPerSample)
            {
                case 8:
                    byte zeroVol = (byte)128;
                    byte maxBuf = (byte)(e.Buffer.Max() - zeroVol);
                    byte minBuf = (byte)(zeroVol - e.Buffer.Min());
                    byte maxVol = Math.Max(maxBuf, minBuf);
                    volumeLevel = maxVol * 100 / 128;
                    break;
                case 16:
                    int maxVolume = 0;
                    for (int i = 0; i < e.BytesRecorded; i += 2)
                    {
                        short sample = (short)((e.Buffer[i + 1] << 8) | e.Buffer[i + 0]);
                        maxVolume = Math.Max(maxVolume, Math.Abs((int)sample));
                    }
                    volumeLevel = maxVolume * 100 / 32768;
                    //volumeLevel = (int)(Math.Log10(maxVolume / 32768) * 20);
                    break;
                default:
                    volumeLevel = 0;
                    break;
            }
        }

        public int GetVolumeLevel()
        {
            MixerLine mixerLine = waveInEvent.GetMixerLine();
            return 0;
        }
    }
}
