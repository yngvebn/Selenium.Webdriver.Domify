using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;

namespace Selenium.Webdriver.Domify.Elements
{
    [DOMElement("input", Type="file")]
    public class FileUpload : WebElement
    {
        public static FileUpload Create(IWebElement element)
        {
            return new FileUpload(element);
        }

        private FileUpload(IWebElement element):
            base(element)
        {
            
        }
        public string File
        {
            get { return GetAttributeValue("value"); }
            set{ SendKeys(value);}
        }
    }
}