using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet3
{
    class CustomBackground
    {
        private static string current = UserFiles.UserDir + @"\" + "_f.dat";

        public static string Current
        {
            get { return current; }
        }
        private static string[] fullPath = new string[] {
            UserFiles.UserDir + @"\" + "1f.dat",
            UserFiles.UserDir + @"\" + "2f.dat",
            UserFiles.UserDir + @"\" + "3f.dat",
            UserFiles.UserDir + @"\" + "4f.dat",
            UserFiles.UserDir + @"\" + "5f.dat",
            UserFiles.UserDir + @"\" + "6f.dat",
            UserFiles.UserDir + @"\" + "7f.dat",
            UserFiles.UserDir + @"\" + "8f.dat",
            UserFiles.UserDir + @"\" + "9f.dat",
            UserFiles.UserDir + @"\" + "0f.dat",

        };
        public static string[] FullPath
        {
            get { return fullPath; }
        }
    }
}
