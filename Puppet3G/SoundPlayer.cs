using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.Threading;
using System.IO;

namespace Puppet3
{
    public class SoundPlayer
    {
        public SoundPlayer()
        {
        }

        public WaveOut waveOut;
        public Mp3FileReader reader;
        private BlockAlignReductionStream baStream;

        public bool Init(string file)
        {
            reader = new Mp3FileReader(file);
            WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader);
            baStream = new BlockAlignReductionStream(pcmStream);

            waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
            waveOut.Init(baStream);
            return true;
        }

        public void Play(int volumeLevel)
        {
            baStream.Position = 0;
            waveOut.Volume = 1.0f * volumeLevel / 100;
            waveOut.Play();
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
        }

        public void Stop()
        {
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
                baStream.Position = 0;
            }
        }

        public void Dispose()
        {
            if(waveOut != null) waveOut.Dispose();
            if(reader != null) reader.Dispose();
            if(baStream != null) baStream.Dispose();
        }
    }
}
