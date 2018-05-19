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
        private static string appName = "Puppet3";
        private static string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + appName;
        public static string UserDir {
            get { return userDir; }
        }

        public static void SetupUserDirectories()
        {
            if (!Directory.Exists(userDir)) Directory.CreateDirectory(userDir);
        }
    }
}
