using NUnit.Framework;
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
            public void ShouldNotBeAbleToFindIfPartialIsFalseAndTextIsPartial()
            {
                var div = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.Div(Find.ByText("Hello", partial: false));
                Assert.That(div, Is.Null);
            }

            [Then]
            public void ShouldBeAbleToFindIfPartialIsTrueAndTextIsPartial()
            {
                var div = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.Div(Find.ByText("World", partial: true));
                Assert.That(div, Is.Null);
            }
    }
}