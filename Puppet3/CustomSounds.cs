using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet3
{
    public class CustomSounds
    {
        private static string current = UserFiles.UserDir + @"\" + "_e.dat";

        public static string Current
        {
            get { return current; }
        }
        private static string[] fullPath = new string[] {
            UserFiles.UserDir + @"\" + "1e.dat",
            UserFiles.UserDir + @"\" + "2e.dat",
            UserFiles.UserDir + @"\" + "3e.dat",
            UserFiles.UserDir + @"\" + "4e.dat",
            UserFiles.UserDir + @"\" + "5e.dat",
            UserFiles.UserDir + @"\" + "6e.dat",
            UserFiles.UserDir + @"\" + "7e.dat",
            UserFiles.UserDir + @"\" + "8e.dat",
            UserFiles.UserDir + @"\" + "9e.dat",
            UserFiles.UserDir + @"\" + "0e.dat",

        };
        public static string[] FullPath
        {
            get { return fullPath; }
        }
    }
}
