using System;
using System.IO;

namespace WEBUIautomation.Utils
{

    ///To Be rewrited to NLog 
    
    //Class for Logging Webdriver events
    public class Logger
    {
        static StreamWriter logStream = null;
        static string logsFolder = "Test Logs";
        static string logsFile = DateTime.Now.ToString("dd_MM_yyyy-HH.mm.ss") + ".html";
        static string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        static string directoryPath = Path.Combine(projectPath, logsFolder);
        static string filePath = Path.Combine(directoryPath, logsFile);

        public enum msgType
        {
            Message,
            Warning,
            Error,
            Passed
        }

        //Creating the screenshots
        public static void Log(string sMessage, msgType msgtype)
        {
            try
            {
                CreateFolder();
                logStream = new StreamWriter(filePath, true);
                switch (msgtype)
                {
                    case msgType.Message:
                        logStream.WriteLine(DateTime.Now.ToString() + " " + sMessage + "<br>");
                        break;
                    case msgType.Warning:
                        logStream.WriteLine(DateTime.Now.ToString() + " <font color='yellow'>" + sMessage + "</font><br>");
                        break;
                    case msgType.Error:
                        logStream.WriteLine(DateTime.Now.ToString() + " <font color='red'><b>" + sMessage + "</b></font><br>");
                        break;
                    case msgType.Passed:
                        logStream.WriteLine("{0} <font color='green'><b>{1}</b></font><br>", DateTime.Now.ToString(), sMessage);
                        break;
                }

            }
            catch (Exception ex)
            {
                Log("Error -" + ex.Message, msgType.Error);
            }
            finally
            {
                if (logStream != null)
                {
                    logStream.Flush();
                    logStream.Dispose();
                }
            }
        }

        private static string CreateFolder()
        {
            if (!File.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }
         
    }


    
}
