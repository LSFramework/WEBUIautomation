using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public static partial class Locators
    {
        public static class ServiceLevelAgreementPage
        {
            public static readonly string btnPrevious = "ctl00_PageContent_btnPrevious";
            public static readonly string btnNext = "ctl00_PageContent_btnNext";
            public static readonly string btnCancel = "ctl00_PageContent_btnCancel";
            public static readonly string btnHelp = "ctl00_PageContent_btnHelp";
            
            public static string radioTransactionResponseTime = "ctl00_PageContent_ctl01_Measurement1";
            public static string ddlComplexLoad = "ctl00_PageContent_ctl01_ddlComplexLoad";
            public static string radioErrorsPerSecond = "ctl00_PageContent_ctl01_Measurement3";
            public static string radioTotalHitsStatusPerRun = "ctl00_PageContent_ctl01_Measurement4";
            public static string radioAverageHitsPerSecond = "ctl00_PageContent_ctl01_Measurement5";
            public static string txtThreshold = "ctl00_PageContent_ctl01_txtThreshold";


        }
    }
}
