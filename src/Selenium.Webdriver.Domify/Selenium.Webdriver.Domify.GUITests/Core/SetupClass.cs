using NUnit.Framework;
using OpenQA.Selenium.IE;
using Selenium.Webdriver.Domify.GUITests.Core;

[SetUpFixture]
public class SetupClass
{
    [SetUp]
    public void StartWebDriver()
    {
        BrowserTestSettings.Driver = new InternetExplorerDriver();

    }

    [TearDown]
    public void KillWebDriver()
    {
        BrowserTestSettings.Driver.Close();
        BrowserTestSettings.Driver.Dispose();
    }
}