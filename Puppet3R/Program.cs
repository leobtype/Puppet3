using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puppet3
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string mutexName = Properties.Settings.Default.Title;
            bool createdNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, mutexName, out createdNew);
            if (createdNew == false)
            {
                MessageBox.Show("多重起動はできません");
                mutex.Close();
                return;
            }
            try
            {
                UserFiles.SetupUserDirectories();
                Properties.Settings.Default.SoundSource = "Microphone";
                SoundPlayer soundPlayer = new SoundPlayer();
                Microphone2 microphone = new Microphone2();
                ApplicationSound appSound = new ApplicationSound();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MascotForm(microphone, soundPlayer, appSound));
            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Close();
            }
            
        }
    }
}
