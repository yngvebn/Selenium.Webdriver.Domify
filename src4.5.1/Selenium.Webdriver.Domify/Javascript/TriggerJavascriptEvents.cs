namespace Selenium.Webdriver.Domify.Javascript
{
    public class TriggerJavascriptEvents : Javascript
    {
        public TriggerJavascriptEvents(params object[] eventNames)
            : base(GetJavascript(), eventNames)
        {

        }

        private static string GetJavascript()
        {
            return "if('createEvent' in document) { " +
                   "for(var i = 1; i<a.length; i++){ var evt = document.createEvent('HTMLEvents'); evt.initEvent(a[i], false, true); a[0].dispatchEvent(evt); } } else for(var i = 1; i<a.length; i++) { a[0].fireEvent('on'+a[i]); }";

        }
    }
}