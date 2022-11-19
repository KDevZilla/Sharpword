using SharpWord.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord.Utility
{
    public class SerializeUtility
    {
        public static void SerializeStatistics(Statistics  sta, String filename)
        {
            //Create the stream to add object into it.  
            Serailze(sta, filename);
        }

        public static void CreateNewStatistics(String filename)
        {
            Statistics sta = new Statistics();
            Serailze(sta, filename);
        }
        public static  Statistics DeserializeStatistics(String filename)
        {
            object obj = Deserialize(filename);
            Statistics sta = (Statistics)obj;
            return sta;
        }
        public static void CreateNewSettings(String filename)
        {
            SharpWordSettings  sta = new SharpWordSettings();
            Serailze(sta, filename);
        }
        public static void SerializeSettings(SharpWordSettings  sta, String filename)
        {
            //Create the stream to add object into it.  
            Serailze(sta, filename);
        }


        public static SharpWordSettings DeserializeSettings(String filename)
        {
            object obj = Deserialize(filename);
            SharpWordSettings sta = (SharpWordSettings)obj;
            return sta;
        }
        // public static void void SerailzeSettings()
        private  static object  Deserialize(String filename)
        {
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
           // Statistics sta = (Statistics)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return obj;

        }

        private static void Serailze(object obj, String filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, obj);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

    }
}
