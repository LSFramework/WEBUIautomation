using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class DefectsPage
    {
        public static void GoTo()
        {
            Driver.Instance.FindElement(By.XPath("//a[@class='dropdown-toggle ng-binding']")).Click();
            //Driver.Instance.FindElement(By.XPath("//ul[@class='dropdown-menu']//a[contains(text(), 'Defects')]")).Click();
        }

        public static void AddDefect(string summary, string severity)
        {
            Driver.Wait(3);
            Driver.Instance.FindElement(By.XPath("//li[@class='add-entity-button ng-scope']/button")).Click();
            Driver.Wait(3);
            Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='name']//input[contains(@class, 'alm-input-box')]")).SendKeys(summary);
            Driver.Instance.FindElement(By.XPath("//form[@name='entityForm']//div[@data-field-name='severity']//input[contains(@class, 'alm-input-box')]")).SendKeys(severity);
            Driver.Instance.FindElement(By.XPath("//button[@class='dialog-btn-primary no-button'][translate[@key='entity-form-add']]")).Click();

        }

        
    }

}
