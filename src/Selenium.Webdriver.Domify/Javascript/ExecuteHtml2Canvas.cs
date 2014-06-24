namespace Selenium.Webdriver.Domify.Javascript
{
    public class ExecuteHtml2Canvas: Javascript
    {
        public ExecuteHtml2Canvas() : base(GetJavascript())
        {
        }

        private static string GetJavascript()
        {
            return Html2Canvas.Javascript + "; html2canvas(document.body, {onrendered: function (canvas) {localStorage.setItem('__s_w_d_screenshot', canvas.toDataURL());}});";
        }
    }
}