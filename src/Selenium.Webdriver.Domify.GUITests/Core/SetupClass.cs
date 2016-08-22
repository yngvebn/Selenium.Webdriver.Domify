using System.Collections.Generic;
using System.IO;
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
        
        DesiredCapabilities dcaps = new DesiredCapabilities();
        dcaps.SetCapability("takesScreenshot", true);
        PhantomJSOptions options = new PhantomJSOptions();

        options.AddAdditionalCapability("phantomjs.binary.path", Path.GetDirectoryName("..\\..\\..\\..\\Drivers\\"));
        
        //BrowserTestSettings.Driver = new ChromeDriver("..\\..\\..\\..\\Drivers\\", options);
        
        BrowserTestSettings.Driver = new PhantomJSDriver(options);

    }

    [TearDown]
    public void KillWebDriver()
    {
        BrowserTestSettings.Driver.Close();
        BrowserTestSettings.Driver.Dispose();
    }
}