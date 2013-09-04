using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using Selenium.Webdriver.Domify.GUITests.Core;

[SetUpFixture]
public class SetupClass
{
    [SetUp]
    public void StartWebDriver()
    {
        //BrowserTestSettings.Driver = new ChromeDriver("..\\..\\..\\..\\Drivers\\");
        BrowserTestSettings.Driver = new PhantomJSDriver("..\\..\\..\\..\\Drivers\\");

    }

    [TearDown]
    public void KillWebDriver()
    {
        BrowserTestSettings.Driver.Close();
        BrowserTestSettings.Driver.Dispose();
    }
}