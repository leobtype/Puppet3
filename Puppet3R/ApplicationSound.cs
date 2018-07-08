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
        private MMDeviceEnumerator deviceEnumerator;
        private MMDevice render;
        private AudioSessionManager renderAudioSessionManager;
        private SessionCollection renderSessions;
        private MMDevice capture;
        private AudioSessionManager captureAudioSessionManager;
        private SessionCollection captureSessions;

        public ApplicationSound()
        {
            Refresh();
        }

        public void Refresh()
        {
            deviceEnumerator = new MMDeviceEnumerator();
            try
            {
                render = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                renderAudioSessionManager = render.AudioSessionManager;
                renderSessions = renderAudioSessionManager.Sessions;
            }
            catch
            {
                // no available speaker device
            }
            try
            {
                capture = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
                captureAudioSessionManager = capture.AudioSessionManager;
                captureSessions = captureAudioSessionManager.Sessions;
            }
            catch
            {
                // no available recording device
            }
            deviceEnumerator.Dispose();
        }

        public List<List<string>> GetApplicationInfo(string dataflow)
        {
            /*  return:
             *      appName[0]: DisplayName
             *      appName[1]: Identifier
             *      appName[2]: ProcessId
             *      appName[3]: SystemSound (True/False)
             */
            SessionCollection sessions;
            switch (dataflow)
            {
                case "Render":
                    sessions = renderSessions;
                    break;
                case "Capture":
                    sessions = captureSessions;
                    break;
                default:
                    sessions = renderSessions;
                    break;
            }
            List<List<string>> applicationInfo = new List<List<string>>();
            if (sessions != null)
            {
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
            }
            return applicationInfo;
        }

        public float GetApplicationVolumeLevel(string dataflow)
        {
            SessionCollection sessions;
            string pid;
            switch (dataflow)
            {
                case "Render":
                    sessions = renderSessions;
                    pid = ApplicationRenderPid;
                    break;
                case "Capture":
                    sessions = captureSessions;
                    pid = ApplicationCapturePid;
                    break;
                default:
                    sessions = renderSessions;
                    pid = "";
                    break;
            }
            float volume = 0.0f;
            if (sessions != null)
            {
                for (int i = 0; i < sessions.Count; i++)
                {

                    if (sessions[i].GetProcessID.ToString() == pid)
                    {
                        volume = sessions[i].AudioMeterInformation.MasterPeakValue;
                    }
                }
            }
            return volume * 100;
        }
    }
}
