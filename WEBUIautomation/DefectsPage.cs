using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class DefectsPage
    {
        public static void GoTo()
        {

            var pageName = DriverWait.Instance.Until<IWebElement>(d => {
                var elements = Driver.Instance.FindElements(By.XPath("//a[@class='dropdown-toggle ng-binding']"));
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            }); 
                
            if (pageName.Text == "Defects")
            {
                pageName.Click();
                Driver.Instance.FindElement(By.XPath("//ul[@class='dropdown-menu']//a[contains(text(), 'Defects')]")).Click();
            }
        }

        public static void AddDefect(string summary, string severity)
        {
            Driver.Wait(3);
            Driver.Instance.FindElement(By.XPath("//li[@class='add-entity-button ng-scope']/button")).Click();
            Driver.Wait(3);
            Driver.Instance.FindElement(By.XPath("//li[@class='add-entity-button ng-scope']/button")).Click();
            Driver.Wait(3);
            Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='name']//input[contains(@class, 'alm-input-box')]")).SendKeys(summary);
            Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='severity']//input[contains(@class, 'alm-input-box')]")).SendKeys(severity);
            Driver.Instance.FindElement(By.XPath("//button[@class='dialog-btn-primary no-button'][translate[@key='entity-form-add']]")).Click();

        }

        public static DefectsCommand AddDefectDialog()
        {
            return new DefectsCommand();
        }
    }

    public class DefectsCommand
    {
        public DefectsCommand()
        {
            Driver.Wait(3);
            Driver.Instance.FindElement(By.XPath("//li[@class='add-entity-button ng-scope']/button")).Click();
            Driver.Wait(3);
        }

        public DefectsCommand SetSummary(string summary)
        {
            Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='name']//input[contains(@class, 'alm-input-box')]")).SendKeys(summary);
            return this;
        }

        public DefectsCommand SetSeverity(string severity)
        {
            Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='severity']//input[contains(@class, 'alm-input-box')]")).SendKeys(severity);
            return this;
        }

        public void Add()
        {
            Driver.Instance.FindElement(By.XPath("//button[@class='dialog-btn-primary no-button'][translate[@key='entity-form-add']]")).Click();
        }
    }

}
