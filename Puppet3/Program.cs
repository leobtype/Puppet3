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
            UserFiles.SetupUserDirectories();
            SoundPlayer soundPlayer = new SoundPlayer();
            Microphone microphone = new Microphone();
            microphone.Setup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MascotForm(microphone, soundPlayer));
        }
    }
}
