using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.ContentLocators;
using WEBUIautomation.Utils;

namespace WEBPages.BasePageObject
{
    public abstract class MainTabBasePage 
    {
        protected abstract MainHead_Links MenuHeader { get; }
        protected abstract Perspectives ViewName { get; }
        protected abstract By byKeyElement { get; }
        
        private MainTabFrame tab;
        protected IWebDriverExt mainTab { get { return tab.mainTab; } }

        protected InitMainTabContext context;

        protected MainTabBasePage()
        {
            context= new InitMainTabContext(MenuHeader,ViewName,byKeyElement);
            tab = new MainTabFrame(context);        
        }

        public bool ViewOpened { get { return tab.ViewOpened; } }
        

    }
}
