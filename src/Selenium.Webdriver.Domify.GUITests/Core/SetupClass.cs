using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using Selenium.Webdriver.Domify.GUITests.Core;

[SetUpFixture]
public class SetupClass
{
    [SetUp]
    public void StartWebDriver()
    {
        var dictionary = new Dictionary<string, List<string>>
        {
            //{"args", new List<string>() {"--window-size=300,300"}}
        };
        var caps = DesiredCapabilities.Chrome();
        caps.SetCapability("chromeOptions", dictionary);
        ChromeOptions options = new ChromeOptions()
        {
            
        };
        //options.AddArgument("--window-size=1,1");
        options.AddArgument("--disable-translate");
        options.AddArgument("--disable-default-apps");
        options.AddArgument("--disable-smooth-scrolling");
        options.AddArgument("--no-autofill-for-password-generation");
        
        BrowserTestSettings.Driver = new ChromeDriver("..\\..\\..\\Packages\\Selenium.WebDriver.ChromeDriver.2.25.0.8\\driver", options);
        
        //BrowserTestSettings.Driver = new PhantomJSDriver("..\\..\\..\\..\\Drivers\\");

    }

    [TearDown]
    public void KillWebDriver()
    {
        BrowserTestSettings.Driver.Close();
        BrowserTestSettings.Driver.Dispose();
    }
}