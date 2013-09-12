using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class SelectLists: PageScenario<HomeSelectLists>
    {
        protected override void When()
        {

        }

        [Then]
        public void WeCanSelectByTextAfterWaiting()
        {
            CurrentPage.DelayedList.WaitUntil(c => c.Options.Count > 1);
            CurrentPage.DelayedList.SelectByText("item2");
            Assert.That(CurrentPage.DelayedList.SelectedOption.Text, Is.EqualTo("item2"));
        }

        [Then]
        public void WeCanSelectByIndexAfterWaiting()
        {
            CurrentPage.DelayedList.WaitUntil(c => c.Options.Count > 1);
            CurrentPage.DelayedList.SelectByIndex(1);
            Assert.That(CurrentPage.DelayedList.SelectedOption.Text, Is.EqualTo("item2"));
        }

        [Then]
        public void WeCanSelectByValueAfterWaiting()
        {
            
            CurrentPage.MainList.SelectByValue("option_2");
            Assert.That(CurrentPage.MainList.SelectedOption.Text, Is.EqualTo("Option 2"));
            Assert.That(CurrentPage.MainList.Options.Single(o => o.IsSelected).Text, Is.EqualTo("Option 2"));
        }
    }
}