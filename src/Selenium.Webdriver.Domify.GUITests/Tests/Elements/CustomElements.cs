using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Elements;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class CustomElements : PageScenario<CustomElementsPage>
    {
        private MyElement element;
        protected override void When()
        {
            element = CurrentPage.MyCustomElement;
        }

        [Then]
        public void ItShouldExist()
        {
            Assert.That(element, Is.Not.Null);
        }

        [Then]
        public void WeCanReadTheText()
        {
            Assert.That(element.Text, Is.EqualTo("Hello world!"));
        }
    }
}