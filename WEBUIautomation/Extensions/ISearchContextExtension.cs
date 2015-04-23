using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using WEBUIautomation.Utils;
using WEBUIautomation.Wait;

namespace WEBUIautomation.Extensions
{
    public static class ISearchContextExtension
    {
        public static bool TryFindElement(this ISearchContext searcher, By by)
        {
            return searcher.TryFindElement(by, TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(200));
        }

        public static bool TryFindElement(this ISearchContext searcher, By by, TimeSpan timeout, TimeSpan pollingInterval)
        {
            Func<bool> canBeFound = () =>
            {
                try
                {
                    searcher.FindElement(by);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            };

            try
            {
                return WaitHelper.SpinWait(canBeFound, timeout, pollingInterval);
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public static bool TryFindElements(this ISearchContext searcher, By by, out IEnumerable<IWebElement> collection, TimeSpan timeout, TimeSpan pollingInterval)
        {
            collection = new List<IWebElement>() as IEnumerable<IWebElement>;
           
                if (searcher.TryFindElement(by, timeout, pollingInterval))
                {
                    var elements = searcher.FindElements(by);

                    if (elements.Count > 0)
                    {
                        collection = elements;
                        return true;
                    }
                }
                else
                {
                    collection = searcher.FindAndWaitCollection(by,timeout,pollingInterval);
                    return true;
                }

                return false;
        }

        private static IReadOnlyCollection<IWebElement> FindAndWaitCollection(this ISearchContext searcher, By by, TimeSpan timeout, TimeSpan pollingInterval)
        {
            var wait = new DefaultWait<ISearchContext>(searcher);
            wait.Timeout = timeout;
            wait.PollingInterval = pollingInterval;

            var collection = wait.Until<IReadOnlyCollection<IWebElement>>
                (s =>
                    {
                        Thread.Sleep(pollingInterval.Milliseconds/2);
                        var elements = s.FindElements(by);
                        if (elements.Count == 0)
                            return null;

                        return elements;
                    }
                );

            return collection;
        } 
 
    }
}
