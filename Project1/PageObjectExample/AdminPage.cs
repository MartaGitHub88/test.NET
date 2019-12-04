using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObjectExample
{
    internal class AdminPage
    {
        private IWebDriver browser;

        public AdminPage(IWebDriver browser)
        {
            this.browser = browser;
        }

        internal string CreateNewNote(ExampleNote exampleNote)
        {
            var noteBox = browser.FindElement(By.LinkText("Wpisy"));
            noteBox.Click();
            var newNoteBox = browser.FindElement(By.CssSelector(".page-title-action"));
            newNoteBox.Click();
            var title = browser.FindElement(By.Id("title"));
            title.SendKeys(exampleNote.Title);
            var content = browser.FindElement(By.Id("content"));
            content.SendKeys(exampleNote.Content);
            browser.FindElement(By.Id("publish")).Submit();
            //WaitForClickable(By.Id("publish"), 5);
            //WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
            var postUrl = browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var url = postUrl.GetAttribute("href");

            return url;
        }

        internal object LogOut()
        {

            MoveToElement(By.Id("wp-admin-bar-top-secondary"));
            WaitForClickable(By.LinkText("Wyloguj się"), 5);
            var logoutButton = browser.FindElement(By.LinkText("Wyloguj się"));
            logoutButton.Click();

            return null;
        }

        internal void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }
        internal void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

    }
}