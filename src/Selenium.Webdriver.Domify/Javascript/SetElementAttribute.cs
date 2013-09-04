namespace Selenium.Webdriver.Domify.Javascript
{
    public class SetElementAttribute: Javascript
    {
        public SetElementAttribute(string attributeName, string attributeValue)
            : base("a[0].setAttribute(a[1], a[2]);", attributeName, attributeValue)
        {
            
        }
    }
}