using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using NAudio;
using NAudio.CoreAudioApi;

namespace Puppet3
{
    public class ApplicationSound
    {
        public string ApplicationRenderPid { get; set; }
        public string ApplicationCapturePid { get; set; }

        public List<List<string>> GetApplicationInfo(string dataflow)
        {
            /*  return:
             *      appName[0]: DisplayName
             *      appName[1]: Identifier
             *      appName[2]: ProcessId
             *      appName[3]: SystemSound (True/False)
             */
            DataFlow df;
            switch (dataflow)
            {
                case "Render":
                    df = DataFlow.Render;
                    break;
                case "Capture":
                    df = DataFlow.Capture;
                    break;
                default:
                    df = DataFlow.All;
                    break;
            }
            List<List<string>> applicationInfo = new List<List<string>>();
            MMDeviceEnumerator deviceEnumerator = (MMDeviceEnumerator)(new MMDeviceEnumerator());
            MMDevice speaker = deviceEnumerator.GetDefaultAudioEndpoint(df, Role.Multimedia);
            AudioSessionManager audioSessionManager = speaker.AudioSessionManager;
            SessionCollection sessions = audioSessionManager.Sessions;
            for (int i = 0; i < sessions.Count; i++)
            {
                bool processIdDuplicate = false;
                foreach (List<string> appinfo in applicationInfo)
                {
                    if (sessions[i].GetProcessID.ToString() == appinfo[2])
                    {
                        processIdDuplicate = true;
                        break;
                    }
                }
                if (processIdDuplicate) continue;
                List<string> info = new List<string>();
                info.Add(sessions[i].DisplayName);
                info.Add(sessions[i].GetSessionInstanceIdentifier.Split('|')[1].Split('%')[0].Split('\\').Last());
                info.Add(sessions[i].GetProcessID.ToString());
                info.Add(sessions[i].IsSystemSoundsSession.ToString());
                applicationInfo.Add(info);
            }
            audioSessionManager.Dispose();
            speaker.Dispose();
            deviceEnumerator.Dispose();
            return applicationInfo;
        }

        public float GetApplicationVolumeLevel(string dataflow)
        {
            DataFlow df;
            string pid;
            switch (dataflow)
            {
                case "Render":
                    df = DataFlow.Render;
                    pid = ApplicationRenderPid;
                    break;
                case "Capture":
                    df = DataFlow.Capture;
                    pid = ApplicationCapturePid;
                    break;
                default:
                    df = DataFlow.All;
                    pid = "";
                    break;
            }
            MMDeviceEnumerator deviceEnumerator = (MMDeviceEnumerator)(new MMDeviceEnumerator());
            MMDevice speaker = deviceEnumerator.GetDefaultAudioEndpoint(df, Role.Multimedia);
            AudioSessionManager audioSessionManager = speaker.AudioSessionManager;
            SessionCollection sessions = audioSessionManager.Sessions;
            float volume = 0.0f;
            for (int i = 0; i < sessions.Count; i++)
            {
 
                if (sessions[i].GetProcessID.ToString() == pid)
                {
                    volume = sessions[i].AudioMeterInformation.MasterPeakValue;
                }
            }
            audioSessionManager.Dispose();
            speaker.Dispose();
            deviceEnumerator.Dispose();
            return volume * 100;
        }
    }
}
