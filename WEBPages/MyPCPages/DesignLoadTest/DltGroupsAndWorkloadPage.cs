using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBPages.Extensions;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;

namespace WEBPages.MyPCPages.DesignLoadTest
{

    using System;
    using Locators = ContentLocators.Locators.DltGroupsAndWorkloadPage;

    public class DltGroupsAndWorkloadPage : WorkLoadBasePage
    {
        protected override WorkloadMenu ViewName { get { return WorkloadMenu.GroupsAndWorkload; } }

        protected override By byKeyElement { get { return Locators.byKeyElement; } }

        public DltGroupsAndWorkloadPage(LoadTest loadTest)
            : base(loadTest)
        { }

        #region Workload Type Dialog private memebers 

        private WebElement btnWorkloadType
        { get { return workload.GetElement().ById(Locators.btnWorkloadType); } }

        private WebElement WorkloadCntrl_btnOk
        { get { return workload.GetElement().ById(Locators.WorkloadCntrl_btnOk); } }

        private WebElement workloadTypeDialog
        {
            get 
            {
                bool loaded= WorkloadDialogLoaded();
                if (!loaded ) //The dialog hasn't been loaded 
                {
                    btnWorkloadTypeClick(); // Load the Dialog
                }

                WebElement _dialogWrapper = workload.GetElement().ById(Locators.WorkloadTypeDialogWrapperId);

                if (_dialogWrapper.GetAttribute(WEBUIautomation.Tags.TagAttributes.Style).Contains(Locators.StyleHiden)) //The dialog was loaded but it is currently hidden
                {
                    btnWorkloadTypeClick(); //Show the dialog
                }                  

                return _dialogWrapper;             
            }
        }

        private bool WorkloadDialogLoaded()
        {
            return workload.TryFindElement(By.Id(Locators.WorkloadTypeDialogWrapperId));                            
        }
                
       

        private DltGroupsAndWorkloadPage checkWorkLoadMode(WorkloadMode mode)
        {
            if (mode == WorkloadMode.SimpleByLTByNumber || mode == WorkloadMode.SimpleByLTByPrecentage)
            {
                string id = WorkloadMode.SimpleByLT.GetEnumDescription();
                WebElement image = workloadTypeDialog.FindRelative().ById(id);
                image.ClickPerform();
            }

            if (mode == WorkloadMode.ComplexByLTByNumber || mode == WorkloadMode.ComplexByLTByPrecentage)
            {
                string id = WorkloadMode.ComplexByLT.GetEnumDescription();
                WebElement image = workloadTypeDialog.FindRelative().ById(id);
                image.ClickPerform();
            }

            WebElement item = workloadTypeDialog.FindRelative().ById(mode.GetEnumDescription());

            item.ClickPerform();

            return this;
        }

        #endregion Workload Type Dialog private memebers


        #region Tree Sliding Panel private memebers

        //The element from we can know is slider shown, hiden, docked
        private WebElement TreeSlidingZone_ClientStateInput 
        { get { return workload.GetElement().ByXPath(Locators.TreeSlidingZone_ClientStateXPath); } }

        private bool SlidingDocked
        {
            get
            {
                string val = TreeSlidingZone_ClientStateInput.GetAttribute(WEBUIautomation.Tags.TagAttributes.Value);
                return val.Contains(Locators.DockedValue);
            }
        }
        private bool SlidingExpanded
        {
            get
            {
                string val = TreeSlidingZone_ClientStateInput.GetAttribute(WEBUIautomation.Tags.TagAttributes.Value);
                return val.Contains(Locators.ExpandedValue);
            }
        }

        public bool ClickSelectTest()
        {
            btnSelectScripts.Click();
            return SlidingExpanded;
        }



        public DltGroupsAndWorkloadPage OpenSlidingTreePanel()
        {
            if (SlidingDocked) return this;

            if (SlidingExpanded) return this;

            //WaitHelper.WithTimeout(TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(500))
            //    .WaitFor(()=>ClickSelectTest());

            WaitHelper.ReTryActionForCondition(
                ()=>btnSelectScripts.Click(), 
                ()=>SlidingExpanded, 
                TimeSpan.FromSeconds(10), 
                TimeSpan.FromMilliseconds(500));

            return this;
        }


        #endregion Tree Slider Panel private memebers

        private WebElement btnSelectScripts
        { get { return workload.GetElement().ById(Locators.SelectScript); } }

        private WebElement scriptsTreePanel
        { get { return workload.GetElement().ById(Locators.ScriptsTreePanel); } }

        private WebElement toolApplySelection
        { get { return workload.GetElement().ById(Locators.toolApplySelection); } }

        private WebElement txtLoadGenerators
        { get { return workload.GetElement().ById(Locators.txtLoadGenerators); } }

        private WebElement btnCollapseScriptsSlidingPane
        { get { return workload.GetElement().ById(Locators.btnCollapseScriptsSlidingPane); } } //


        private DltGroupsAndWorkloadPage btnWorkloadTypeClick()
        {
            btnWorkloadType.Click();
            return this;
        }


        public DltGroupsAndWorkloadPage AddScript(string folderName, string scriptName)
        {
            OpenSlidingTreePanel();
            workload.TryExpandTreeFolder("Subject");
            workload.TryExpandTreeFolder(folderName);
            workload.FindTreeItemByName(scriptName).Click();
            WaitHelper.Wait(workload.WaitProfile.PollingInterval.Milliseconds);
            toolApplySelection.ClickPerform();
            WaitHelper.Wait(workload.WaitProfile.PollingInterval.Milliseconds);

            return this;
        }

        public DltGroupsAndWorkloadPage SetWorkloadMode(WorkloadMode mode)
        {
            checkWorkLoadMode(mode);
            WaitHelper.Wait(500);
            WorkloadCntrl_btnOk.Click();
            WaitHelper.Wait(1000);
            workload.AcceptAlert();
            return this;
        }

        public DltGroupsAndWorkloadPage AddNumberOfLGs(int number)
        {
            //txtLoadGenerators.Click();
            txtLoadGenerators.TextInt = number;
            WaitHelper.ReTryActionForCondition(
                ()=>txtLoadGenerators.TextInt= number, 
                ( )=>txtLoadGenerators.TextInt==number,
                TimeSpan.FromSeconds(10), 
                TimeSpan.FromMilliseconds(500));

            return this;
        }


        public DltGroupsAndWorkloadPage CollapseScriptsSlidingPane()
        {
            if (SlidingDocked || SlidingExpanded) 
                btnCollapseScriptsSlidingPane.Click();

            return this;
        }

    }
}
