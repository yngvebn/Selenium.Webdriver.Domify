using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [HEADElement("base")]
    public class Base : WebElement
    {
        public string Href
        {
            get { return this.GetAttribute("href"); }
        }

        public string Target
        {
            get { return this.GetAttribute("target"); }
        }
    }
}