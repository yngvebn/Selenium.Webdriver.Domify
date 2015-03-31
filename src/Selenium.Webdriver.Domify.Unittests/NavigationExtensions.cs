using System;
using System.Text;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Unittests.DummyPages;

namespace Selenium.Webdriver.Domify.Unittests
{
    [TestFixture]
    public class NavigationExtensionTests
    {
        private INavigationService _navigationService;
        private IDocument _document;
        private IWebDriver _driver;
        private string _currentUrl;

        [SetUp]
        public void InitializeNavigationService()
        {
            var driverMock = new Mock<IWebDriver>();
            driverMock.Setup(c => c.Url).Returns(() => _currentUrl);
            _driver = driverMock.Object;
            _document = new Document(_driver);
            _navigationService = new NavigationService(_document);
        }

        [Test]
        public void ShouldResolveIsAtPageCorrectly()
        {
            _currentUrl = "http://can.be.anything/resource/";
            Assert.That(_navigationService.IsAtPage<SimplePage>(), Is.True);
        }

    }

}