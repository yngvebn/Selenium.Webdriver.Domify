using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    public class UncheckRadioButtonTests : PageScenario<RadioButtonPage>
    {
        protected override void When()
        {
            CurrentPage.Radio2.Checked = true;
        }

        [Then]
        public void TheOtherRadioButtonShouldNotBeChecked()
        {
            Assert.That(CurrentPage.Radio1.Checked, Is.False);
            Assert.That(CurrentPage.Radio2.Checked, Is.True);
        }
    }
}