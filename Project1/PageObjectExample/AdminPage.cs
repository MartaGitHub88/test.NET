using System;
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

        internal object CreateNewNote(ExampleNote exampleNote)
        {
            var noteBox = browser.FindElement(By.LinkText("Wpisy"));
            noteBox.Click();
            var newNoteBox = browser.FindElement(By.CssSelector(".page-title-action"));
            newNoteBox.Click();
            var title = browser.FindElement(By.Id("title"));
            title.SendKeys(exampleNote.Title);
            var content = browser.FindElement(By.Id("content"));
            content.SendKeys(exampleNote.Content);

            return new AdminPage(browser);
        }
    }
}