using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Webdriver.Domify
{

    public static class Knockout
    {

        public static By ByValue(string value)
        {
            return new DataBoundConstraint(value);
        }

        public static By ByClick(string value)
        {
            return new DataBoundConstraint(value, "click");
        }

        public static By ByText(string value)
        {
            return new DataBoundConstraint(value, "text");
        }

        public static By ByChecked(string value)
        {
            return new DataBoundConstraint(value, "checked");
        }

        public static By ByForeach(string value)
        {
            return new DataBoundConstraint(value, "foreach");
        }

        public class DataBoundConstraint : By
        {
            public DataBoundConstraint(string knockoutParam, string valueAccessor = "value")
            {

                string regex = valueAccessor + ":(.?)" + knockoutParam.Replace("$", "\\$");
                FindElementMethod = context =>
                {
                    var element = context.FindElements(By.XPath(".//*[@data-bind]")).SingleOrDefault(d => Regex.IsMatch(d.GetAttribute("data-bind"), regex));
                    if (string.IsNullOrEmpty(element.GetAttribute("id")))
                    {
                        var finder = string.Format("document.querySelector('[{0}=\"{1}\"]')", "data-bind", element.GetAttribute("data-bind"));

                        string selId = "('id', '_id__'+(Math.floor(Math.random()*10000000)+1));";
                        string js = finder + ".setAttribute" + selId + ";";
                        ((IWrapsDriver)element).WrappedDriver.ExecuteJavascript(js);
                    }
                    return element;
                };

            }
        }


    }
}