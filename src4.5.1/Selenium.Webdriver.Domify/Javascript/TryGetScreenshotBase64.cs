namespace Selenium.Webdriver.Domify.Javascript
{
    public class TryGetScreenshotBase64 : Javascript
    {
        public TryGetScreenshotBase64() : base(GetJavascript())
        {
            
        }

        private static string GetJavascript()
        {
            return "return document.getElementById('__s_w_d_screenshot') ? document.getElementById('__s_w_d_screenshot').innerText : ''";
        }
    }
}