using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SharpWord.Utility
{
    public class PathUtility
    {
        public static string CurrentPath
        {
            get
            {
               String ExePath= new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                return Path.GetDirectoryName(ExePath);
             //   logFilePath = logFilePath.Replace(".exe", "");
            }
        }
        private static string _WordFileName = @"word.txt";
        public static string WordFileName { get { return _WordFileName; } set { _WordFileName = value; }}
        public static string WordFilePath
        {
            get
            {
                return CurrentPath + @"\" + WordFileName;
            }
        }
        public static string StatisticPath
        {
            get
            {
                return CurrentPath + @"\statistics.bin";
            }
        }

        public static string SettingsPath
        {
            get
            {
                return CurrentPath + @"\Settings.bin";
            }
        }
        public static string LogFilePath
        {
            get
            {
                return CurrentPath + @"\" + "SharpWord.log";
            }
        }
    }
}
