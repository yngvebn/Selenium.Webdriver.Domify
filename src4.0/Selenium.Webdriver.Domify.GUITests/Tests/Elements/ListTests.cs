using System.Collections.Generic;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class ListTests: BrowserScenario
    {
        private const string ListId = "textbox1";

        protected override void Given()
        {
            Document.Navigation.GoTo<GenericElementPage>(new { id = ListId, tag = "ul", type ="", childTags ="li,li,,li,li"  });
           
        }

        private UL list;
        protected override void When()
        {
            list = Document.Navigation.GetCurrentPage<GenericElementPage>().Document.List(ListId);
        }



        [Then]
        public void CanGetListItemAtSpecificIndex()
        {
            Assert.That(list[2], Is.Not.Null);
        }

    }
}