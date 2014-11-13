using System;

namespace Selenium.Webdriver.Domify.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HEADElementAttribute : DOMElementAttribute
    {
        public HEADElementAttribute(string tag)
            :base(tag)
        {
            
        }
    }
}