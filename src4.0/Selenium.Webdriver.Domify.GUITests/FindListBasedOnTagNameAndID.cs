using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    public class FindingCheckboxShouldOnlyReturnCheckboxes: BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }


        protected override void When()
        {
        }

        [Then]
        public void WeShouldFindTheCheckBoxes()
        {
            var list = Document.Find<CheckBox>();

            Assert.That(list.All(box => box.GetAttributeValue("type").Equals("checkbox")));
            Assert.That(list.Count(), Is.EqualTo(4));

        }

        [Then]
        public void TheAlternateSearchForCheckboxesShouldReturnTheSame()
        {
            var list = Document.CheckBoxes;

            Assert.That(list.All(box => box.GetAttributeValue("type").Equals("checkbox")));
            Assert.That(list.Count(), Is.EqualTo(4));

        }
    }

    public class FindListBasedOnTagNameAndID: BrowserScenario
    {
        protected override void Given()
        {
            Document.Navigation.GoTo<HomeIndex>();
        }


        protected override void When()
        {
        }

        [Then]
        public void WeShouldFindTheList()
        {
            var list = Document.Find<UL>(By.Id("innerLIst")).SingleOrDefault();
            Assert.That(list.OwnListItems.First().Text, Is.EqualTo("Inner item 1"));
        }
    }
}