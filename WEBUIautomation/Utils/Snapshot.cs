using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WEBUIautomation.Utils
{
    //Class to take screenshots
    public class Snapshot
    {
        //Creating the screenshots
        public static string Take(string methodName)
        {

            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                            Screen.PrimaryScreen.Bounds.Y,
                            0,
                            0,
                            Screen.PrimaryScreen.Bounds.Size,
                            CopyPixelOperation.SourceCopy);

            string fileName = CreateScreenShotFileName(methodName);

            bmpScreenshot.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);

            return fileName;
        }

        private static string CreateScreenShotFileName(string methodName)
        {
            
            string currentTime = Regex.Replace(DateTime.Now.ToLongTimeString(), @"[\: ]", "_");
            string backslash =@"\";

            return string.Format("{0}{1}{2}_{3}.png", CreateFolder(), backslash, methodName, currentTime);            
        }

        private static string CreateFolder()
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
