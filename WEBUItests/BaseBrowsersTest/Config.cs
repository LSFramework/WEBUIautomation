using System;
using System.Collections.Generic;
using System.Configuration;
using WEBUIautomation;

namespace WEBUItests.BaseBrowsersTest
{

    /// <summary>
    /// Implements access to testdata variables from a file
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Returns the App.config value for requested key, or default value if not defined.
        /// </summary>
        /// <param name="key">Application configuration key</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        private static string GetConfigValue(string key, string defaultValue)
        {
            string setting = ConfigurationManager.AppSettings[key];
            
            if (setting == null)
                return defaultValue;         

            return setting;
        }

        /// <summary>
        /// Access point to list of browsers from .config to be tested
        /// </summary>
        public static List<string> BrowsersSet
        { 
            get 
            { 
                return GetBrowsersFromConfig() ;
            } 
        }

        
        /// <summary>
        /// Gets browsers from .config file
        /// </summary>
        /// <returns>List of browsers to testing</returns>
        private static List<string> GetBrowsersFromConfig()
        {
            Browser browserResult;
            //creating an empty storage for browsers' list
            var browsers = new List<string>();

            //If config contains only one default browser like as <add key="Browser" value="Chrome" />
            string browser = Config.GetConfigValue("Browser", "null");            
            if(browser!="null")browsers.Add(browser);


            //Reads first 5 possible keys on below format from .config
            //<add key="Browser1" value="Chrome" />
            //<add key="Browser2" value="Firefox" />
            //<add key="Browser3" value="IE" />
            for (int i = 1; i < 5; i++)
            {
                //string iterator
                browser = Config.GetConfigValue("Browser" + i, "null");
                
                //if value exists and it is a browser
                if (browser != "null" && Enum.TryParse<Browser>(browser, out browserResult))
                        browsers.Add(browser);
            }
            
            //If .config is empty 
            if (browsers.Count == 0)
                browsers.Add(Browser.Firefox.ToString());
            
            return browsers;
        }
    }
}
