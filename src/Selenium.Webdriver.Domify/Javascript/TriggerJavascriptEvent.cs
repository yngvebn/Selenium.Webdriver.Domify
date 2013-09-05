namespace Selenium.Webdriver.Domify.Javascript
{
    public class TriggerJavascriptEvent : Javascript
    {
        public TriggerJavascriptEvent(string eventName)
            :base(GetJavascript(), eventName)
        {
            
        }

        private static string GetJavascript()
        {
            return "if('createEvent' in document) { var evt = document.createEvent('HTMLEvents'); evt.initEvent(a[1], false, true); a[0].dispatchEvent(evt); } else a[0].fireEvent('on'+a[1]);";

        }
    }
}