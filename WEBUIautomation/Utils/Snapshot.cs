using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
{
    //Class to take screenshots
    public class Snapshot
    {
        //Creating the screenshots
        public static void Take()
        {
            Screenshot ss = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            StackTrace stackTrace = new StackTrace();
            string methodName = stackTrace.GetFrame(1).GetMethod().Name;
            string currentTime = DateTime.Now.ToShortTimeString().ToString().Replace(":","_");
            //System.Console.WriteLine(methodName);
            //string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("C:\\Utils\\" + methodName + "_" + currentTime + ".png", System.Drawing.Imaging.ImageFormat.Png);
            //ss.ToString();
        }

        public static void Take(string name)
        {
            Screenshot ss = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            //StackTrace stackTrace = new StackTrace();
            //string methodName = stackTrace.GetFrame(1).GetMethod().Name;
            //string currentTime = DateTime.Now.ToShortTimeString().ToString().Replace(":", "_");
            //System.Console.WriteLine(methodName);
            //string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("C:\\Utils\\" + name +".png", System.Drawing.Imaging.ImageFormat.Png);
            //ss.ToString();
        }

        //Event for taking screenshots
        public void TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            //Take();
            Screenshot ss = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            //StackTrace stackTrace = new StackTrace();
            //string methodName = stackTrace.GetFrame(1).GetMethod().Name;
            string currentTime = Regex.Replace(DateTime.Now.ToLongTimeString(), @"[\: ]", "_");
            //string browserName = Driver.Capabilities.BrowserName; 
            //System.Console.WriteLine(methodName);
            //string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(CreateFolder() + @"\" + "Exception_" + /*browserName +*/ currentTime + ".png", System.Drawing.Imaging.ImageFormat.Png);
            //ss.ToString();
        }

        private string CreateFolder()
        {
            string snapshotFolder = "Tests_Snapshots";
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string newPath = Path.Combine(projectPath, snapshotFolder);

            if (!File.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            return newPath;
        }

    }
}
