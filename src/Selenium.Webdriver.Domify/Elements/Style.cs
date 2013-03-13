using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify.Elements
{
    public class Style
    {
        private readonly IWebElement _element;

        public Style(IWebElement element)
        {
            _element = element;
            CssText = _element.GetAttribute("style");
            
        }

        public HtmlColor BackgroundColor { get { return new HtmlColor(_element.GetCssValue("background-color")); } }
        public HtmlColor Color { get { return new HtmlColor(_element.GetCssValue("color")); } }
        //
        // Summary:
        //     Retrieves the CSS text.
        public string CssText { get; private set;}
        //
        // Summary:
        //     Retrieves wheter the object is rendered.
        //
        public string Display { get { return _element.GetCssValue("display"); } }
        //
        // Summary:
        //     Retrieves the name of the font used for text in the element.
        public string FontFamily { get { return _element.GetCssValue("font-family"); } }
        //
        // Summary:
        //     Retrieves a value that indicates the font size used for text in the element.
        public string FontSize { get { return _element.GetCssValue("font-size"); } }
        //
        // Summary:
        //     Retrieves the font style of the element as italic, normal, or oblique.
        public string FontStyle { get { return _element.GetCssValue("font-style"); } }
        //
        // Summary:
        //     Retrieves the height of the element.
        public string Height { get { return _element.GetCssValue("height"); } }


        public string GetAttributeValue(string attributeName)
        {
            return _element.GetCssValue(attributeName);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}