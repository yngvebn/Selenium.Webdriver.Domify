namespace Selenium.Webdriver.Domify.Javascript
{
    public class SetElementCss: Javascript
    {
        public SetElementCss(string style, string styleValue)
            : base(string.Format("a[0].style.{0} = a[1];", style), styleValue)
        {

        }
    }
}