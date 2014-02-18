using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [HEADElement("meta")]
    public class Meta : WebElement
    {
        public new string Name { get { return this.GetAttribute("name"); } }

        public string Content
        {
            get { return this.GetAttribute("content"); }
        }

        public string Charset
        {
            get { return this.GetAttribute("charset"); }
        }

        public string HttpEquiv
        {
            get { return this.GetAttribute("http-equiv"); }
        }

    }
}