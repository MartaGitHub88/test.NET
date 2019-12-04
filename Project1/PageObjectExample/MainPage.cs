using OpenQA.Selenium;

namespace PageObjectExample
{
    internal class MainPage
    {
        private const string MAIN_PAGE_BASE_URL = "http://automatyzacja.benedykt.net";
        private readonly IWebDriver browser;
        private MainPage(IWebDriver browser)
        {
            this.browser = browser;
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }

        internal static MainPage Open(IWebDriver browser)

        {
            return new MainPage(browser);


        }


        internal NotePage NavigateToNewestNote()
        {
            var latestNote = browser.FindElement(By.CssSelector(".entry-title > a"));
            latestNote.Click();

            return new NotePage(browser);

        }

    }
}