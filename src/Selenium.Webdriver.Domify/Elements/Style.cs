using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("style")]
    public class Style : WebElement
    {
        public string Media
        {
            get { return this.GetAttribute("media"); }
        }

        public string Scoped
        {
            get { return this.GetAttribute("scoped"); }
        }

        public string Type
        {
            get { return this.GetAttribute("type"); }
        }
    }
}