

namespace WEBPages.Pages
{

    public class ALMainPage: DriverContainer
    {
        public MyPCLoginPage GoToMyPC(string MyPCUrl)
        {                    
            driver.Navigate().GoToUrl(MyPCUrl);
            return new MyPCLoginPage();
        }
    }
}
