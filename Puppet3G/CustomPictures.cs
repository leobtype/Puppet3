using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet3
{
    public class CustomPictures
    {
        private static string[] current = new string[]
        {
            UserFiles.UserDir + @"\" + "_a.dat",
            UserFiles.UserDir + @"\" + "_b.dat",
            UserFiles.UserDir + @"\" + "_c.dat",
            UserFiles.UserDir + @"\" + "_d.dat"
        };
        public static string[] Current
        {
            get { return current; }
        }
        private static string[] fullPath = new string[] {
            UserFiles.UserDir + @"\" + "1a.dat",
            UserFiles.UserDir + @"\" + "1b.dat",
            UserFiles.UserDir + @"\" + "1c.dat",
            UserFiles.UserDir + @"\" + "1d.dat",
            UserFiles.UserDir + @"\" + "2a.dat",
            UserFiles.UserDir + @"\" + "2b.dat",
            UserFiles.UserDir + @"\" + "2c.dat",
            UserFiles.UserDir + @"\" + "2d.dat",
            UserFiles.UserDir + @"\" + "3a.dat",
            UserFiles.UserDir + @"\" + "3b.dat",
            UserFiles.UserDir + @"\" + "3c.dat",
            UserFiles.UserDir + @"\" + "3d.dat",
            UserFiles.UserDir + @"\" + "4a.dat",
            UserFiles.UserDir + @"\" + "4b.dat",
            UserFiles.UserDir + @"\" + "4c.dat",
            UserFiles.UserDir + @"\" + "4d.dat",
            UserFiles.UserDir + @"\" + "5a.dat",
            UserFiles.UserDir + @"\" + "5b.dat",
            UserFiles.UserDir + @"\" + "5c.dat",
            UserFiles.UserDir + @"\" + "5d.dat",
            UserFiles.UserDir + @"\" + "6a.dat",
            UserFiles.UserDir + @"\" + "6b.dat",
            UserFiles.UserDir + @"\" + "6c.dat",
            UserFiles.UserDir + @"\" + "6d.dat",
            UserFiles.UserDir + @"\" + "7a.dat",
            UserFiles.UserDir + @"\" + "7b.dat",
            UserFiles.UserDir + @"\" + "7c.dat",
            UserFiles.UserDir + @"\" + "7d.dat",
            UserFiles.UserDir + @"\" + "8a.dat",
            UserFiles.UserDir + @"\" + "8b.dat",
            UserFiles.UserDir + @"\" + "8c.dat",
            UserFiles.UserDir + @"\" + "8d.dat",
            UserFiles.UserDir + @"\" + "9a.dat",
            UserFiles.UserDir + @"\" + "9b.dat",
            UserFiles.UserDir + @"\" + "9c.dat",
            UserFiles.UserDir + @"\" + "9d.dat",
            UserFiles.UserDir + @"\" + "0a.dat",
            UserFiles.UserDir + @"\" + "0b.dat",
            UserFiles.UserDir + @"\" + "0c.dat",
            UserFiles.UserDir + @"\" + "0d.dat"
        };
        public static string[] FullPath
        {
            get { return fullPath; }
        }
    }
}
