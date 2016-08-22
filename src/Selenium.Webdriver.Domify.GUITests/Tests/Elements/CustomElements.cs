using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
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

    public class DocumentHeadTests : PageScenario<PageWithHeaderInfo>
    {
        protected override void When()
        {
            
        }

        [Then]
        public void ItShouldExist()
        {
            Assert.That(CurrentPage.Title, Is.EqualTo("Pagewithheadinfo"));
        }

        [Then]
        public void WeCanGetMetaDescription()
        {
            Assert.That(CurrentPage.MetaDescription, Is.EqualTo("Automated testing"));
        }

        [Then]
        public void WeCanGetStyleSheetUrl()
        {
            Assert.That(CurrentPage.Document.Header.Links.Single(link => link.Rel == LinkRel.Stylesheet).Href, Is.EqualTo("http://can.be.anything/style.css"));
        }
    }
}