using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("script")]
    public class Script : WebElement
    {
        public string Charset
        {
            get { return this.GetAttribute("charset"); }
        }

        public string Src
        {
            get { return this.GetAttribute("src"); }
        }

        public string Async
        {
            get { return this.GetAttribute("async"); }
        }

        public string Defer
        {
            get { return this.GetAttribute("defer"); }
        }

        public string Type
        {
            get { return this.GetAttribute("type"); }
        }
    }
}