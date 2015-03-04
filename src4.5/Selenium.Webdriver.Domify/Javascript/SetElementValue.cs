namespace Selenium.Webdriver.Domify.Javascript
{
    public class SetElementValue: Javascript
    {
        public SetElementValue(string val)
            :base("a[0].value = a[1]", val)
        {
            
        }
    }
}