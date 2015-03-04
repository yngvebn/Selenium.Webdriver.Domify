using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Helpers;

namespace Selenium.Webdriver.Domify.Elements
{
    [HEADElement("link")]
    public class Link : WebElement
    {
        public string Charset
        {
            get { return this.GetAttribute("charset"); }
        }

        public string Href
        {
            get { return this.GetAttribute("href"); }
        }

        public string HrefLang
        {
            get { return this.GetAttribute("hreflang"); }
        }

        public string Media
        {
            get { return this.GetAttribute("media"); }
        }
        public string Sizes
        {
            get { return this.GetAttribute("sizes"); }
        }
        public string Target
        {
            get { return this.GetAttribute("target"); }
        }
        public string Type
        {
            get { return this.GetAttribute("type"); }
        }
        public LinkRel Rel
        {
            get { return this.GetAttribute("rel").CastTo<LinkRel>(); }
        }
    }
}