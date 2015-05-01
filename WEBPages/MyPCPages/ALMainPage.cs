using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{

    public class ALMainPage : DriverContainer
    {
        public MyPCLoginPage GoToMyPC(string MyPCUrl)
        {
            driver.Navigate().GoToUrl(MyPCUrl);
            return new MyPCLoginPage();
        }
    }
}
