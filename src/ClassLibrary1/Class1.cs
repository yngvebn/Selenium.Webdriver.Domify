using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Webdriver.Domify;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\temp\selenium"))
            {
                driver.Document().Navigation.GoTo(new Uri("http://localhost:31337/"));
                var link = driver.Document().TextField("textbox");
            }

        }
    }
}
