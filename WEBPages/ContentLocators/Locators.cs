using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public static partial class Locators
    {
        public static class MyPCLoginPage
        { 
            public const string txtUserNameID   = "ctl00_PageContent_txtUserName";
            public const string txtPasswordID   = "ctl00_PageContent_txtPassword";
            public const string btnAuthenticateID = "ctl00_PageContent_btnAuthenticate";
            public const string ddlDomains_ArrowID = "ctl00_PageContent_ddlDomains_Arrow";
            public const string ddlDomains_InputID = "ctl00_PageContent_ddlDomains_Input";
            public const string ddlDomains_DropDownID = "ctl00_PageContent_ddlDomains_DropDown";
            public const string ddlProjects_ArrowID = "ctl00_PageContent_ddlProjects_Arrow";
            public const string ddlProjects_InputID = "ctl00_PageContent_ddlProjects_Input";
            public const string ddlProjects_DropDownID = "ctl00_PageContent_ddlProjects_DropDown";
            public const string btnLoginID = "ctl00_PageContent_btnLogin";
        }

        public static class MainHeadPage
        {
            public const string ViewLocator = "Main Head";
            public const string FrameLocatorID = "MastheadDiv";
            public const string MainTabID = "MainTab";
        }

        public static class TestPlanPage
        {
            public const string txtFindNodeID = "ctl00_PageContent_WebPartManager";
        }
    }
}
