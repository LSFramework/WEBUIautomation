using OpenQA.Selenium;
using WEBUIautomation;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject.DLTBase;
using WEBPages.MyPCPages.TestRunDialog;

namespace WEBPages.BasePageObject
{
    using Locators = ContentLocators.Locators.DltBasePage;
  
    public abstract class WorkLoadBasePage : IWorkLoadBasePage
    {
        protected abstract WorkloadMenu ViewName { get; }
        protected abstract By byKeyElement { get; }

        protected WorkloadContext context;

        private DltMainFrame dltMainFrame;
       
        protected WorkLoadBasePage(LoadTest loadTest)
        {
            context = new WorkloadContext(ViewName, byKeyElement);
            dltMainFrame = new DltMainFrame(loadTest);
        }

        private IWebDriverExt actions { get { return dltMainFrame.ActionsFrame; } }
        
        protected IWebDriverExt workload { get { return dltMainFrame.WorkloadFrame(context); } }       

        protected WebElement actionMessage { get { return actions.GetElement().ById(Locators.actionMessageId); } }
        protected WebElement btnSaveAndRun { get { return actions.GetElement().ById(Locators.btnSaveAndRunId); } }
        protected WebElement btnSave { get { return actions.GetElement().ById(Locators.btnSaveId); } }
        protected WebElement btnClose { get { return actions.GetElement().ById(Locators.btnCloseId); } }
        protected WebElement btnOptions { get { return actions.GetElement().ById(Locators.btnOptionsId); } }
        protected WebElement btnHelp { get { return actions.GetElement().ById(Locators.btnHelpId); } }

        public bool ViewOpened { get { return workload.GetElement().BySelenium(context.byKeyElement).Displayed; } }

        public void Save()
        {
            btnSave.ClickPerform();
        }

        public StartRunDialog Run()
        {
            btnSaveAndRun.ClickPerform();
            return new StartRunDialog();
        }
    }
}
