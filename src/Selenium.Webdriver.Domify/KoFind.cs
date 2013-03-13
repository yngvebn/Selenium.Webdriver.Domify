using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    public static class KoFind
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
                FindElementMethod = context => context.FindElement(XPath(string.Format(".//*[matches(@data-bind,'{0}')]", regex)));
            }
        }


    }
}