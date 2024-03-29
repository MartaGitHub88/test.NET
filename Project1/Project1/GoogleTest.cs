﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using Xunit;

namespace Project1
{
    public class GoogleTest : IDisposable
    {
        IWebDriver browser;
        Actions builder;
        public GoogleTest()
        { 
            browser = new ChromeDriver();
            builder = new Actions(browser);
        }

        [Fact]
        public void Can_Google_Weather_For_Warsaw()
        {
            browser.Navigate().GoToUrl("https://www.google.pl/");
            var queryBox = browser.FindElement(By.CssSelector(".gLFyf"));
            queryBox.Click();
            queryBox.SendKeys("pogoda warszawa");
            queryBox.Submit();

            var result = browser.FindElement(By.Id("wob_tm"));

            Assert.Equal("3", result.Text);

        }

        [Fact]
        public void Can_Add_Comment()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");
            var queryBox = browser.FindElement(By.CssSelector(".entry-title"));
            var link = queryBox.FindElement(By.TagName("a"));
            link.Click();

            Actions moveTo = builder.MoveToElement(browser.FindElement(By.Id("comment")));
            moveTo.Build().Perform();

            var commentBox = browser.FindElement(By.Id("comment"));
            commentBox.Click();
            commentBox.SendKeys("hello Marta");

            builder.MoveToElement(browser.FindElement(By.Id("email")));
            moveTo.Build().Perform();

            var signBox = browser.FindElement(By.Id("author"));
            signBox.Click();
            signBox.SendKeys("Marta");

            builder.MoveToElement(browser.FindElement(By.Id("url")));
            moveTo.Build().Perform();

            var emailBox = browser.FindElement(By.Id("email"));
            emailBox.Click();
            emailBox.SendKeys("testynmb@gmail.com");

            builder.MoveToElement(browser.FindElement(By.CssSelector(".nav-links")));
            moveTo.Build().Perform();

            browser.FindElement(By.Id("submit")).Submit();
        }

        [Fact]
        public void Can_Add_New_Comment()
            {
                browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");
                var latestNote = browser.FindElement(By.CssSelector(".entry-title > a"));
                latestNote.Click();
                var comment = browser.FindElement(By.Id("comment"));
                var exampleText = Faker.Lorem.Paragraph();
                comment.SendKeys(exampleText);
                var author = browser.FindElement(By.Id("author"));
                var exampleName = Faker.Name.FullName();
                author.SendKeys(exampleName);
                var email = browser.FindElement(By.Id("email"));
                var exampleEmail = Faker.Internet.Email();
                email.SendKeys(exampleEmail);
                MoveToElement(browser.FindElement(By.CssSelector(".nav-links")));

                browser.FindElement(By.Id("submit")).Submit();

                var comments = browser.FindElements(By.CssSelector("article.comment-body"));
                var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleName)
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleText);

                Assert.Single(myComments);

        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();



        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
