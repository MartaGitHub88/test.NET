using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectExample
{
    internal class LoginPage
    {
        private const string MAIN_PAGE_BASE_URL = "http://automatyzacja.benedykt.net/wp-admin";
        private readonly IWebDriver browser;
        private LoginPage(IWebDriver browser)
        {
            this.browser = browser;


        }

        internal AdminPage Login(string user, string password)
        {
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
            WaitForClickable(By.CssSelector("#user_login"), 5);
            var LoginBox = browser.FindElement(By.CssSelector("#user_login"));
            LoginBox.SendKeys(user);
            var PasswordBox = browser.FindElement(By.CssSelector("#user_pass"));
            PasswordBox.SendKeys(password);
            var Submit = browser.FindElement(By.Id("wp-submit"));
            Submit.Submit();

            return new AdminPage(browser);
        }

        internal static object CreateNewestNote()
        {
            throw new NotImplementedException();
        }

        internal static LoginPage Open(IWebDriver browser)

        {
            return new LoginPage(browser);
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}