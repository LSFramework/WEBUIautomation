using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using WEBUIautomation;

namespace WEBUItests.TestVariables
{
    /// <summary>
    /// Implements access to testdata variables from a file
    /// </summary>
    public class Config
    {
        /// <summary>
        /// UserName
        /// </summary>
        public static string UserName { get { return GetConfigValue("UserName", "sa"); } }
      
        /// <summary>
        /// Password
        /// </summary>       
        public static string UserPassword { get { return GetConfigValue("UserPassword", ""); } }
      
     
        /// <summary>
        /// Domain Name
        /// </summary>         
        public static string DomainName { get { return GetConfigValue("DomainName", "TestDomain"); } }
       
        /// <summary>
        /// Project
        /// </summary>         
        public static string ProjectName { get { return GetConfigValue("ProjectName", "TestProject"); } }


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
                return GetBrowsers() ;
            } 
        }

        
        /// <summary>
        /// Gets browsers from .config file
        /// </summary>
        /// <returns>List of browsers to testing</returns>
        private static List<string> GetBrowsers()
        {
            Browsers browserResult;
            var browsers = new List<string>();

            string browser = Config.GetConfigValue("Browser", "null");            
            if(browser!="null")browsers.Add(browser);


            //Reads first 5 possible keys on below format from .config
            //<add key="Browser1" value="chrome" />
            //<add key="Browser2" value="firefox" />
            //<add key="Browser3" value="ie" />
            for (int i = 1; i < 5; i++)
            {
                //string iterator
                browser = Config.GetConfigValue("Browser" + i, "null").ToLower();
                
                //if value exists and it is a browser
                if (browser != "null" && Enum.TryParse<Browsers>(browser, out browserResult))
                        browsers.Add(browser);
            }
            
            //If .config is empty 
            if (browsers.Count == 0)
                browsers.Add(Browsers.firefox.ToString());
            
            return browsers;
        }

        /// <summary>
        /// Gets MyPCUrl
        /// </summary>
        public static string MyPCUrl
        {
            get { return GetMyPCUrl(); }
        }

        private static string GetMyPCUrl()
        {
            string result;
            string AlmServer= Config.GetConfigValue("Server", "");
            string Port=Config.GetConfigValue("Port", "8080");
            string MyPC_Url_prefix = Config.GetConfigValue("MyPC_Url_prefix", @"/qcbin/loadtest/");
            
            result= string.Format("{0}:{1}{2}",AlmServer,Port,MyPC_Url_prefix);
            return result;
        }
       
    }
}
