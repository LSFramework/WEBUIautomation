﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
{
    public static class Snapshot
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

        public static void TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            //Take();
            Screenshot ss = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            //StackTrace stackTrace = new StackTrace();
            //string methodName = stackTrace.GetFrame(1).GetMethod().Name;
            string currentTime = DateTime.Now.ToShortTimeString().Replace(":", "_");
            //string browserName = Driver.Capabilities.BrowserName; 
            //System.Console.WriteLine(methodName);
            //string screenshot = ss.AsBase64EncodedString;
            //byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("C:\\Utils\\" + "Snapshot_on_exception_" + /*browserName +*/ currentTime + ".png", System.Drawing.Imaging.ImageFormat.Png);
            //ss.ToString();
        }
    }
}