using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Finders
{
    public class PageAttributeFinder: PageScenario<HomeIndexWithAttributes>
    {
        protected override void Given()
        {
            Document.Settings.BaseUri = new Uri("http://localhost:31337");
            base.Given();
        }

        [Then]
        public void WeShouldFindTheElement()
        {
            
            Assert.That(CurrentPage.TextBox, Is.Not.Null);
        }

        protected override void When()
        {

        }
    }
}