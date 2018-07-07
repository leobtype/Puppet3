using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Puppet3
{
    public class UserFiles
    {
        private static string appName = Properties.Settings.Default.Title;
        public static string UserDir { get; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + appName;

        public static void SetupUserDirectories()
        {
            if (!Directory.Exists(UserDir)) Directory.CreateDirectory(UserDir);
        }
    }
}
