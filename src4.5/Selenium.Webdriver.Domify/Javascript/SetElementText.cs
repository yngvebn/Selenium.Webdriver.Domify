namespace Selenium.Webdriver.Domify.Javascript
{
    public class SetElementText: Javascript
    {
        public SetElementText(string text):base("a[0].textContent = a[1];", text)
        {
            
        }
    }
}