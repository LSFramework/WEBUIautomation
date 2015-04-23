using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using WEBUIautomation.Wait;

namespace WEBUIautomation.Utils
{
    //extended IWebDriver interface
    public interface IWebDriverExt : IWebDriver
    {
        WaitProfile WaitProfile { get; }
        By CurrentFrame { get; set; }
        string CurrentView { get; set; }
    }

    #region IWebDriverExt instances implementations for some browsers

   
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }

        public FirefoxDriverExt() : base() { }
        public FirefoxDriverExt(FirefoxProfile profile) : base(profile) { }
        public FirefoxDriverExt(DesiredCapabilities capabilities) : base(capabilities) { }

        public FirefoxDriverExt(FirefoxProfile profile, WaitProfile waitProfile)
            : this(profile)
        {
            WaitProfile = waitProfile;
        }

    }

    
    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {
        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }
        
        public ChromeDriverExt(string path) : base(path) { }
        public ChromeDriverExt(string path, ChromeOptions options) : base(path, options) { }
        public ChromeDriverExt(string path, ChromeOptions options, TimeSpan commandTimeout) : base(path, options, commandTimeout) { }
        
        public ChromeDriverExt(string path, ChromeOptions options, TimeSpan commandTimeout, WaitProfile waitProfile)
            :this ( path,  options,  commandTimeout)
        {
            this.WaitProfile = waitProfile;        
        }      
       
    }

   
    public class InternetExplorerDriverExt : InternetExplorerDriver, IWebDriverExt
    {
        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }

        public InternetExplorerDriverExt(string path) : base(path) { }
        public InternetExplorerDriverExt(string path, InternetExplorerOptions options) : base(path, options) { }

        public InternetExplorerDriverExt(string path, InternetExplorerOptions options, WaitProfile waitProfile) : this(path, options) 
        {
            WaitProfile = waitProfile;
        }
    }

    public class PhantomJSDriverExt : PhantomJSDriver, IWebDriverExt
    {
        public PhantomJSDriverExt(string path) : base(path) { }
        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }
    }

    public class EventFiringWebDriverExt : EventFiringWebDriver, IWebDriverExt
    {      
        public EventFiringWebDriverExt(IWebDriver parentDriver) : base(parentDriver) { }
        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }
    }

    #endregion
}
