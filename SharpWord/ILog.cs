using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord
{
    public interface  ILog
    {
         void Log(String Message);
    }
    public class StringBuilderLog : ILog
    {
        public StringBuilder Builder = new StringBuilder();
        public void Log(String Message)
        {
            Builder.Append(Message).Append(Environment.NewLine);
        }
    }

    //This is just for debugging 
    //Please use the real logging library such as log4net
    public class TextLog : ILog
    {
        private string filePath = "";
        public TextLog(String pfilePath)
        {
            filePath = pfilePath;
        }
        public void Log(String Message)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.Create(filePath);
                }

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    Message = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss:") + Message;
                    writer.WriteLine(Message);
                }
            }
            catch (Exception ex)
            {
                //Sorry we really cannot do anything
            }
        }
    }
}
