using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using WEBUIautomation.Tags;
using WEBUIautomation.Extensions;
using System.Globalization;
using WEBUIautomation.Wait;
using System.Threading;
using OpenQA.Selenium.Interactions;


namespace WEBUIautomation.WebElement
{
    internal enum SelectTypes
    {
        ByValue,
        ByText
    }

    public partial class WebElement
    {
        #region Common properties
        
        public int Count
        {
            get { return FindIWebElements().Count; }
        }

        public bool Enabled
        {
            get { return FindSingle().Enabled; }
        }

        public bool Displayed
        {
            get { return FindSingle().Displayed; }
        }

        public bool Selected
        {
            get { return FindSingle().Selected; }
        }

        public string Text
        {
            set
            {
                var element = FindSingle();

                if (element.TagName == TagNames.Input.GetEnumDescription() || element.TagName == TagNames.TextArea.GetEnumDescription())
                {
                    element.Clear();
                }
                else
                {
                    element.SendKeys(Keys.LeftControl + "a");
                    element.SendKeys(Keys.Delete);
                }

                if (string.IsNullOrEmpty(value)) return;

                try
                {
                   // SendKeys("");
                    SendKeys(value);  
                    WaitHelper.Wait(Browser.WaitProfile.PollingInterval.Milliseconds);
                }
                catch
                {
                    Browser.ExecuteJavaScript(string.Format("arguments[0].value = \"{0}\";", value), element);

                    WaitHelper.Try(() => FireJQueryEvent(JavaScriptEvents.KeyUp));
                }
                finally
                {
                    ClearSearchResultCache();
                }
            }

            get
            {
                var element = FindSingle();

                return !string.IsNullOrEmpty(element.Text) ? element.Text : element.GetAttribute(TagAttributes.Value.GetEnumDescription());
            }
        }

        private void SendKeys(string value, IWebElement element)
        {
            element.SendKeys(value);
            Browser.WaitReadyState();
            element = FindSingle();
            if (element.Text != value)
                throw new Exception();
        }

        public int TextInt
        {
            set { DoAction(()=>Text = value.ToString(CultureInfo.InvariantCulture)); }
            get { return Text.ToInt(); }
        }

        public string InnerHtml
        {
            get { return Browser.ExecuteJavaScript("return arguments[0].innerHTML;", FindSingle()).ToString(); }
        }

        #endregion

        #region Common methods        


        public bool IsEnabled()
        {
            return FindSingle().Enabled;
        }

        public bool Exists()
        {
            return FindIWebElements().Any();
        }

        public bool Exists(TimeSpan timeSpan)
        {

            return WaitHelper.SpinWait(Exists, timeSpan, Browser.WaitProfile.PollingInterval);
        }

        public bool Exists(int seconds)
        {
            return WaitHelper.SpinWait(Exists, TimeSpan.FromSeconds(seconds), Browser.WaitProfile.PollingInterval);
        }

        public void Click(bool useJQuery = false)
        {
            if (useJQuery)
            {
               FireJQueryEvent(JavaScriptEvents.Click);
               return;
            }
            
            DoAction( () => FindSingle().Click() );

        }

       

        public void ClickPerform()
        {
            
            Actions action = new Actions(Browser);

            action.MoveToElement(FindSingle()).Perform();

            action.ClickAndHold().Perform();

            WaitHelper.Wait(Browser.WaitProfile.PollingInterval);

            action.Release().Perform();
          

            ClearSearchResultCache();
        }

        public void Clear()
        {
            FindSingle().Clear();
            ClearSearchResultCache();
        }

        public void SendKeys(string keys)
        {
            DoAction( () => FindSingle().SendKeys(keys) );
        }

        public void SetCheck(bool value, bool useJQuery = true)
        {
            var element = FindSingle();

            Contract.Assert(element.Enabled);

            const int tryCount = 10;

            for (var i = 0; i < tryCount; i++)
            {
                element = FindSingle();

                Set(value, useJQuery);

                if (element.Selected == value)
                {
                    return;
                }
            }

            Contract.Assert(element.Selected == value);

            ClearSearchResultCache();

        }

        public void Select(string optionValue)
        {
            DoAction( () => SelectCommon(optionValue, SelectTypes.ByValue) );
        }

        public void Select(int optionValue)
        {
            SelectCommon(optionValue.ToString(CultureInfo.InvariantCulture), SelectTypes.ByValue);
            ClearSearchResultCache();

        }

        public void SelectByText(string optionText)
        {
            SelectCommon(optionText, SelectTypes.ByText);
        }

        public void MouseOver()
        {
        
            FireJQueryEvent(FindSingle(), JavaScriptEvents.MouseOver);
            
            ClearSearchResultCache();
        }



        // Summary:
        //     Gets the value of the specified attribute for this element.
        //
        // Parameters:
        //   attributeName:
        //     The name of the attribute.
        //
        // Returns:
        //     The attribute's current value. Returns a null if the value is not set.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The OpenQA.Selenium.IWebElement.GetAttribute(System.String) method will return
        //     the current value of the attribute, even if the value has been modified after
        //     the page has been loaded. Note that the value of the following attributes
        //     will be returned even if there is no explicit attribute on the element: Attribute
        //     nameValue returned if not explicitly specifiedValid element typescheckedcheckedCheck
        //     BoxselectedselectedOptions in Select elementsdisableddisabledInput and other
        //     UI elements
        public string GetAttribute(TagAttributes tagAttribute)
        {
            Browser.WaitReadyState(); /// Something wrong with the method
                                      /// 
            WaitHelper.Wait(1000); /// Waiting for attributes have been changed successfully
                                
            string attributeName = tagAttribute.GetEnumDescription();

            return FindSingle().GetAttribute(attributeName);
        }

        #endregion

        #region Additional methods

        public void SwitchContext()
        {
            var element = FindSingle();

            _searcher = element as ISearchContext;
           // Browser.SwitchToFrame(element);
        }

        public void CacheSearchResult()
        {
            _searchCache = FindIWebElements();
        }

        public void ClearSearchResultCache()
        {
            _searchCache = null;
        }

        public void DragAndDrop(WebElement destination)
        {
            var source = FindSingle();
            var dest = destination.FindSingle();

            Browser.DragAndDrop(source, dest);
        }

        public void FireJQueryEvent(JavaScriptEvents javaScriptEvent)
        {
            var element = FindSingle();

            FireJQueryEvent(element, javaScriptEvent);
        }

        public void ForEach(Action<WebElement> action)
        {
            Contract.Requires(action != null);

            CacheSearchResult();

            Enumerable.Range(0, Count).ToList().ForEach(i => action(ByIndex(i)));

            ClearSearchResultCache();
        }

        public List<T> Select<T>(Func<WebElement, T> action)
        {
            Contract.Requires(action != null);

            var result = new List<T>();

            ForEach(e => result.Add(action(e)));

            return result;
        }

        public List<WebElement> Where(Func<WebElement, bool> action)
        {
            Contract.Requires(action != null);

            var result = new List<WebElement>();

            ForEach(e =>
            {
                if (action(e)) result.Add(e);
            });

            return result;
        }

        public WebElement Single(Func<WebElement, bool> action)
        {
            return Where(action).Single();
        }

        #endregion

        #region Helpers

        protected void DoAction(Action action)
        {
            Func<bool> readyForAction = () =>
            {

                try
                {
                    var element = FindSingle();
                    if (element.Enabled && element.Displayed)
                    {
                        Browser.Highlight(element);
                        return true;
                    }
                    else
                    {
                        MoveToVisible(element);
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            };

            WaitHelper.SpinWait(readyForAction, Browser.WaitProfile.Timeout, Browser.WaitProfile.PollingInterval);

            try
            {
                action();
            }
            catch (StaleElementReferenceException)
            {
                ClearSearchResultCache();
                WaitHelper.Try(action);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message.Contains("Element is not clickable"))
                {
                    WaitHelper.SpinWait(readyForAction, Browser.WaitProfile.Timeout, Browser.WaitProfile.PollingInterval);
                    WaitHelper.Try(action);
                }
            }
            catch (ElementNotVisibleException)
            {
                MoveToVisible(FindSingle());
                WaitHelper.Try(action);
            }
            catch (WebDriverTimeoutException e)
            {
                string message = string.Format("Can't find single element with given search criteria: {0}", SearchCriteriaToString());
                
                throw new WebDriverTimeoutException(message, e.InnerException);
            }
            catch
            {
                throw;
            }
            finally
            {
                ClearSearchResultCache();
                Thread.Sleep(Browser.WaitProfile.PollingInterval.Milliseconds / 2);
                Browser.WaitReadyState();
            }
        }

        private void Set(bool value, bool useJQuery = true)
        {
            if (Selected ^ value)
            {
                Click(useJQuery);
            }
        }

        private void SelectCommon(string option, SelectTypes selectType)
        {
            Contract.Requires(!string.IsNullOrEmpty(option));

            var element = FindSingle();

            Contract.Assert(element.Enabled);

            switch (selectType)
            {
                case SelectTypes.ByValue:
                    new SelectElement(element).SelectByValue(option);
                    return;
                case SelectTypes.ByText:
                    new SelectElement(element).SelectByText(option);
                    return;
                default:
                    throw new Exception(string.Format("Unknown select type: {0}.", selectType));
            }
        }

        private void FireJQueryEvent(IWebElement element, JavaScriptEvents javaScriptEvent)
        {
            var eventName = javaScriptEvent.GetEnumDescription();
            Browser.ExecuteJavaScript(string.Format("arguments[0].style.visibility='visible'; $(arguments[0]).{0}();", eventName), element);
        }

        private void MoveToVisible(IWebElement element)
        {
            Browser.ExecuteJavaScript(String.Format("window.scrollTo(0,{0});", element.Location.Y));
            Browser.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
            Browser.WaitReadyState();
        }

        #endregion
               
    }

    public enum JavaScriptEvents
    {
        [Description("keyup")]
        KeyUp,

        [Description("click")]
        Click,

        [Description("mouseover")]
        MouseOver
    }
}
