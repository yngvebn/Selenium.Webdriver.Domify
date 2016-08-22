using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Extensions;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class ScreenshotTests : PageScenario<NoPage>
    {
        protected override void Given()
        {
            if(File.Exists("test.jpg")) File.Delete("test.jpg");
            Document.Settings.BaseUri = new Uri("https://lag.rikstoto.no/");
            base.Given();
        }

        [Test]
        public void AScreenshotShouldExist()
        {
            Assert.That(File.Exists("test.jpg"));
        }

        protected override void When()
        {
            Document.Navigation.GoTo("https://lag.rikstoto.no/");
            Document.SetWindowSize(new Size(768, 1024));
            var phantomJsDriver = ((PhantomJSDriver)Document.Driver);
            phantomJsDriver.Manage().Window.Maximize();
            phantomJsDriver.TakeScreenshot().SaveAsFile("test.jpg", ImageFormat.Jpeg);
            
        }

    }

    public class NoPage : Page
    {
    }

    [TestFixture]
    public class ButtonTests : PageScenario<HomeButtons>
    {
        protected override void Given()
        {
            Document.Settings.BaseUri = new Uri("http://localhost:31338");
            base.Given();
        }
        

        [Then]
        public void WeShouldFindSixButtons()
        {
            Assert.That(CurrentPage.Document.Buttons().Count, Is.EqualTo(6));

              
        }

        [Then]
        public void AllButtonsShouldHaveText()
        {
            Assert.That(CurrentPage.Document.Buttons().All(button => !string.IsNullOrEmpty(button.Text)));
        }

        protected override void When()
        {
            Document.SetWindowSize(new Size(768,1024));
        }
    }
}