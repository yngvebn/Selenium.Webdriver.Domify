namespace Selenium.Webdriver.Domify.Javascript
{
    public class ExecuteHtml2Canvas: Javascript
    {
        public ExecuteHtml2Canvas() : base(GetJavascript())
        {
        }

        private static string GetJavascript()
        {
            return Html2Canvas.Javascript+"; html2canvas(document.body, {onrendered: function (canvas) {var el = document.createElement('div');var content = document.createTextNode(canvas.toDataURL());el.id = '__s_w_d_screenshot';el.appendChild(content);document.body.appendChild(el);cnv = canvas;}});";
        }
    }
}