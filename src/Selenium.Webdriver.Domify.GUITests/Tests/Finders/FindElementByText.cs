using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Finders
{
    public class FindElementByText : BrowserScenario
    {
            private const string ListId = "textbox1";

            protected override void Given()
            {
                Document.Navigation.GoTo<GenericElementPage>(new { id = ListId, tag = "div",text = "Hello world", type = ""});

            }

            protected override void When()
            {
                
            }



            [Then]
            public void ShouldBeAbleToFindDivWithExactMatch()
            {
                var div = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.Div(Find.ByText("Hello world", partial: false));
                Assert.That(div, Is.Not.Null);
            }

            [Then]
            [ExpectedException(typeof(NotFoundException))]
            public void ShouldNotBeAbleToFindIfPartialIsFalseAndTextIsPartial()
            {
                var div = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.Div(Find.ByText("Hello", partial: false));
                Assert.That(div, Is.Null);
            }

            [Then]
            public void ShouldBeAbleToFindIfPartialIsTrueAndTextIsPartial()
            {
                var div = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.Div(Find.ByText("world", partial: true));
                Assert.That(div, Is.Not.Null);
            }

        [Then]
        public void ShouldBeAbleToFindElementByTextWithinElement()
        {
            var currentPage = Document.Navigation.GetCurrentPage<GenericElementPage>();
            var root = Document.Div("body-div");
            var div = root.Div(Find.ByText("Hello world"));
            Assert.That(div, Is.Not.Null);
        }
    }
}