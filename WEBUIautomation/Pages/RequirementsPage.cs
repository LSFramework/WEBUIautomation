using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class RequirementsPage
    {
        /*
        [FindsBy(How = How.XPath, Using = "//li[@class='add-entity-button ng-scope']/button")]
        private IWebElement addReqButton;

        [FindsBy(How = How.XPath, Using = "//form[@name='entityForm']//div[@data-field-name='name']//input[contains(@class, 'alm-input-box')]")]
        private IWebElement setName;

        [FindsBy(How = How.XPath, Using = "//form[@name='entityForm']//div[@data-field-name='type-id']//input[contains(@class, 'alm-input-box')]")]
        private IWebElement setType;

        [FindsBy(How = How.XPath, Using = "//form[@name='entityForm']//div[@data-field-name='father-name']//input[contains(@class, 'alm-input-box')]")]
        private IWebElement setParent;

        [FindsBy(How = How.XPath, Using = "//button[@class='dialog-btn-primary no-button'][translate[@key='entity-form-add']]")]
        private IWebElement addButton;
        */

        public static void GoTo()
        {
            var pageName = DriverWait.Instance.Until<IWebElement>(d =>
            {
                var elements = Driver.Instance.FindElements(By.XPath("//a[@class='dropdown-toggle ng-binding']"));
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });

            if (pageName.Text != "Requirements")
            {
                pageName.Click();
                Driver.Instance.FindElement(By.XPath("//ul[@class='dropdown-menu']//a[contains(text(), 'Requirements')]")).Click();
            }
            
        }

        public static RequirementsCommand AddReq()
        {
            //PageFactory.InitElements(Driver.Instance, new RequirementsCommand());
            return new RequirementsCommand();
        }

        public class RequirementsCommand
        {
            public RequirementsCommand()
            {
                
                Driver.Instance.FindElement(By.XPath("//li[@class='add-entity-button ng-scope']/button")).Click();
            }

            public RequirementsCommand SetName(string name)
            {
                var nameField = Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='name']//input[contains(@class, 'alm-input-box')]"));
                nameField.Click();
                nameField.Clear();
                nameField.SendKeys(name);
                return this;
            }

            public RequirementsCommand SetParent(string parent)
            {
                Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='father-name']//input[contains(@class, 'alm-input-box')]")).Click();
                Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='father-name']//a[@title='" + parent + "']")).Click();
                    
                    //.SendKeys(parent);
                return this;
            }

            public RequirementsCommand SetType(string type)
            {
                Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='type-id']//input[contains(@class, 'alm-input-box')]")).Click();
                Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='type-id']//a[@title='" + type + "']")).Click();
                return this;
            }

            public void ClickAdd()
            {
                Driver.Instance.FindElement(By.XPath("//button[@class='dialog-btn-primary no-button'][translate[@key='entity-form-add']]")).Click();
            }
        }

    }

    

   
}
