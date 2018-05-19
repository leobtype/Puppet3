using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Puppet3
{
    public partial class Microphone
    {
        public void SetWaveFormat(SupportedWaveFormat waveFormat)
        {
            switch (waveFormat)
            {
                case SupportedWaveFormat.WAVE_FORMAT_1M08:
                    waveInEvent.WaveFormat = new WaveFormat(11025, 8, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_1M16:
                    waveInEvent.WaveFormat = new WaveFormat(11025, 16, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_1S08:
                    waveInEvent.WaveFormat = new WaveFormat(11025, 8, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_1S16:
                    waveInEvent.WaveFormat = new WaveFormat(11025, 16, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_2M08:
                    waveInEvent.WaveFormat = new WaveFormat(22050, 8, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_2M16:
                    waveInEvent.WaveFormat = new WaveFormat(22050, 16, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_2S08:
                    waveInEvent.WaveFormat = new WaveFormat(22050, 8, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_2S16:
                    waveInEvent.WaveFormat = new WaveFormat(22050, 16, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_44M08:
                    waveInEvent.WaveFormat = new WaveFormat(44100, 8, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_44M16:
                    waveInEvent.WaveFormat = new WaveFormat(44100, 16, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_44S08:
                    waveInEvent.WaveFormat = new WaveFormat(44100, 8, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_44S16:
                    waveInEvent.WaveFormat = new WaveFormat(44100, 16, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_48M08:
                    waveInEvent.WaveFormat = new WaveFormat(48000, 8, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_48M16:
                    waveInEvent.WaveFormat = new WaveFormat(48000, 16, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_48S08:
                    waveInEvent.WaveFormat = new WaveFormat(48000, 8, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_48S16:
                    waveInEvent.WaveFormat = new WaveFormat(48000, 16, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_96M08:
                    waveInEvent.WaveFormat = new WaveFormat(96000, 8, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_96M16:
                    waveInEvent.WaveFormat = new WaveFormat(96000, 16, 1);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_96S08:
                    waveInEvent.WaveFormat = new WaveFormat(96000, 8, 2);
                    break;
                case SupportedWaveFormat.WAVE_FORMAT_96S16:
                    waveInEvent.WaveFormat = new WaveFormat(96000, 16, 2);
                    break;
                default:
                    waveInEvent.WaveFormat = new WaveFormat(44100, 16, 1);
                    break;
            }
        }
    }
}
