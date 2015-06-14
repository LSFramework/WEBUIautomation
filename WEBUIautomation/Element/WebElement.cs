using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using System.Collections.ObjectModel;
using WEBUIautomation.Wait;

namespace WEBUIautomation.WebElement
{
    public partial class WebElement : ICloneable
    {
        private ISearchContext _searcher;

        private By _firstSelector;

        private IList<IWebElement> _searchCache;

        private IWebDriverExt Browser { get { return Driver.Instance; } }
        
        public WebElement()
            : this(Driver.Instance)
        { }

        public WebElement ReturnFound()
        {
             FindSingle();
             return this;
        }

        private WebElement(ISearchContext searcher)
        {
            _searcher = searcher;
        }

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
                WaitHelper.Wait(Browser.WaitProfile.PollingInterval.Milliseconds);
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

            // ReSharper disable UnusedVariable
            var elementAccess = element.Enabled;
            // ReSharper restore UnusedVariable                             
            
            return element;
        }

        private IList<IWebElement> FindIWebElements()
        {
            if (_searchCache != null)
            {
                return _searchCache;
            }

            var resultEnumerable = new List<IWebElement>() as IEnumerable<IWebElement>;

            bool found=_searcher.TryFindElements(_firstSelector, out resultEnumerable, Browser.WaitProfile.Timeout, Browser.WaitProfile.PollingInterval);

            if (!found)
                throw new NoSuchElementException(string.Format("Can't find any element with given search criteria: {0}.",
                    SearchCriteriaToString()));

            if (resultEnumerable.ToList().Count == 1)
            {
                _searchCache = resultEnumerable.ToList();
                return _searchCache;
            }
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
                Logger.Log(e.StackTrace, Logger.msgType.Error);
                return new List<IWebElement>();
            }

            _searchCache = resultEnumerable.ToList();
            return _searchCache;           
        }

        private WebElementNotFoundException WebElementNotFoundException
        {
            get
            {
                return new WebElementNotFoundException
                    (string.Format("Can't find single element with given search criteria: {0}. Current driver frame is {1} , Current driver view is {2}",
                    SearchCriteriaToString(), 
                    Browser.CurrentFrame.ToString(), 
                    Browser.CurrentView));
            }
        }

        public WebElement FindRelative()
        {
            var searcher = FindSingle();

            return new WebElement(searcher);              
        }

        public WebElement GetParent()
        {
            var searcher = FindSingle();

            var element = new WebElement(searcher);
            
            element._firstSelector = By.XPath("..");
            
            element.FindSingle();
            
            return element;
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
