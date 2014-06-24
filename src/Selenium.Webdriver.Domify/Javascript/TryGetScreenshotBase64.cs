namespace Selenium.Webdriver.Domify.Javascript
{
    public class TryGetScreenshotBase64 : Javascript
    {
        public TryGetScreenshotBase64() : base(GetJavascript())
        {
            
        }

        private static string GetJavascript()
        {
            return "var bs64 = localStorage.getItem('__s_w_d_screenshot');localStorage.removeItem('__s_w_d_screenshot');return bs64;";
        }
    }
}