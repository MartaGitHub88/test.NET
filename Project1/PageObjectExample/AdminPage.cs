using OpenQA.Selenium;

namespace PageObjectExample
{
    internal class AdminPage
    {
        private IWebDriver browser;

        public AdminPage(IWebDriver browser)
        {
            this.browser = browser;
        }
    }
}