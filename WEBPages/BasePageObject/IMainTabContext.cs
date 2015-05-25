using OpenQA.Selenium;
using System;
using WEBPages.ContentLocators;

namespace WEBPages.BasePageObject
{
    interface IMainTabContext
    {
        By byKeyElement { get; }
        MainHead_Links MenuHeader { get; }
        Perspectives ViewName { get; }
    }
}
