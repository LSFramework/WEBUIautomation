using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using WEBUIautomation.Wait;

namespace WEBUIautomation.WebElement
{
    public partial class WebElement : ICloneable
    {
       
        private By _firstSelector;

        private IList<IWebElement> _searchCache;

        private IWebDriverExt Browser = Driver.Instance;

        private IWebElement FindSingle()
        {
            return TryFindSingle();            
        }
                
        private IWebElement TryFindSingle()
        {
            Contract.Ensures(Contract.Result<IWebElement>() != null);

            try
            {
                return FindSingleIWebElement();
            }
            catch (StaleElementReferenceException)
            {
                ClearSearchResultCache();
               
                return FindSingleIWebElement();
            }
            catch (InvalidSelectorException)
            {
                throw;
            }
            catch (WebDriverException)
            {
                throw;
            }
            catch (WebElementNotFoundException)
            {
                throw;
            }
            catch
            {
                throw WebElementNotFoundException;
            }
        }

        private IWebElement FindSingleIWebElement()
        {
            var elements = FindIWebElements();

            if (!elements.Any()) throw WebElementNotFoundException;

            var element = elements.Count() == 1
                ? elements.Single()
                : _index == -1
                    ? elements.Last()
                    : elements.ElementAt(_index);
            // ReSharper disable UnusedVariable
            var elementAccess = element.Enabled;
            // ReSharper restore UnusedVariable


            Browser.ScrollToElement(element);
            Browser.Highlight(element);     
            
            
            return element;
        }

        private IList<IWebElement> FindIWebElements()
        {
            if (_searchCache != null)
            {
                return _searchCache;
            }            

            Browser.WaitScript();

            Browser.WaitReadyState();

            IEnumerable<IWebElement> resultEnumerable = new List<IWebElement>() as IEnumerable<IWebElement>;

            if (Browser.IsElementPresent(_firstSelector))
            {
                Exception e = null;
                Browser.TryFindElements(_firstSelector, out resultEnumerable, out e);
            }
            else
            {
                DefaultWait<IWebDriverExt> wait = new DefaultWait<IWebDriverExt>(Browser);
                wait.Timeout = TimeSpan.FromSeconds(10);
                wait.PollingInterval = TimeSpan.FromMilliseconds(100);

                resultEnumerable = wait.Until(driver =>
                    {
                        Thread.Sleep(wait.PollingInterval);

                        var elements = Browser.FindElements(_firstSelector);

                        if (elements.Count > 0)
                            return elements as IEnumerable<IWebElement>;
                        else return null;
                    });
            }

            resultEnumerable = Browser.FindElements(_firstSelector) as IEnumerable<IWebElement>;

            try
            {
                resultEnumerable = FilterByVisibility(resultEnumerable).ToList();
                resultEnumerable = FilterByTagNames(resultEnumerable).ToList();
                resultEnumerable = FilterByText(resultEnumerable).ToList();
                resultEnumerable = FilterByTagAttributes(resultEnumerable).ToList();
                resultEnumerable = resultEnumerable.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<IWebElement>();
            }

            var resultList = resultEnumerable.ToList();

            return resultList;
        }

        private WebElementNotFoundException WebElementNotFoundException
        {
            get
            {
                return new WebElementNotFoundException(string.Format("Can't find single element with given search criteria: {0}.",
                    SearchCriteriaToString()));
            }
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public WebElement Clone()
        {
            return (WebElement)MemberwiseClone();
        }
    }
}
