namespace Selenium.Webdriver.Domify.XPath
{
    public class XPathConstructor
    {
        public static string Construct(string tagName, string attributeName = "", string attributeValue = "")
        {
            string xpath = tagName;
            if(!string.IsNullOrEmpty(attributeName))
            {
                xpath += string.Format("[@{0}='{1}']", attributeName, attributeValue);
            }
            return xpath;
        }
    }

    
}