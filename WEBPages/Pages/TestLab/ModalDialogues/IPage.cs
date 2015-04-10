using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    interface IPage
    {
        string Url { get; }
        string ViewLocator { get; }
        By FrameLocator { get; }
    }
}
