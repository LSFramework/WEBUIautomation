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
                throw;// WebElementNotFoundException;
            }
        }

        private IWebElement FindSingleIWebElement()
        {
           
            var elements = FindIWebElements();


            if (!elements.Any())
                throw WebElementNotFoundException;

            var element = elements.Count() == 1
                ? elements.Single()
                : _index == -1
                    ? elements.Last()
                    : elements.ElementAt(_index);           


           // Browser.ScrollToElement(element);

            // ReSharper disable UnusedVariable
            var elementAccess = element.Enabled;
            // ReSharper restore UnusedVariable

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

            var resultEnumerable = new List<IWebElement>() as IEnumerable<IWebElement>;            
            Exception ex = null;

            Browser.TryFindElements(_firstSelector, out resultEnumerable, out ex);

            if (resultEnumerable.ToList().Count == 1) 
                return resultEnumerable.ToList();

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

            return resultEnumerable.ToList();           
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
