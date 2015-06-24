using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using System.IO;
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
        public int PID;
        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }

        public FirefoxDriverExt(FirefoxProfile profile ) :base(profile)
        {
            profile.SetPreference("profile", "default");
            this.WaitProfile = new WaitProfile(TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(100));
        }
    }

    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {

        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }
        
        public ChromeDriverExt(string path, ChromeOptions options, TimeSpan commandTimeout, WaitProfile waitProfile)
            : base(path, options, commandTimeout)
        {
            this.WaitProfile = waitProfile;
     
        }

        public ChromeDriverExt()
            :this ( DirectoryHelper.ChromeDirectory(), 
                    new ChromeOptions(), TimeSpan.FromSeconds(10),
                    new WaitProfile(TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(200))) 
        { }
                
    }
 
    public class InternetExplorerDriverExt : InternetExplorerDriver, IWebDriverExt
    {

        public By CurrentFrame { get; set; }
        public string CurrentView { get; set; }
        public WaitProfile WaitProfile { get; private set; }

        public InternetExplorerDriverExt(string path, InternetExplorerOptions options) : base(path, options) { }

        public InternetExplorerDriverExt(string path, InternetExplorerOptions options, WaitProfile waitProfile) 
            : this(path, options) 
        {
            WaitProfile = waitProfile;
        }

        public InternetExplorerDriverExt()
            : this(DirectoryHelper.IEServerDirectory(), 
                    new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        EnsureCleanSession = true,
                        InitialBrowserUrl = "about:blank",
                        EnableNativeEvents = true
                    }, 
                    new WaitProfile(TimeSpan.FromSeconds(10), 
                    TimeSpan.FromMilliseconds(100))
            ) 
        { }
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
