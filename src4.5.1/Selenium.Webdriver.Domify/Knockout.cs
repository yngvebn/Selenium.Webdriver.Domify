using System;
using System.Collections.ObjectModel;
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

        public static By ByWith(string value)
        {
            return new DataBoundConstraint(value, "with");
        }
        
        public static By ByChecked(string value)
        {
            return new DataBoundConstraint(value, "checked");
        }

        public static By ByForeach(string value)
        {
            return new DataBoundConstraint(value, "foreach");
        }

        public static DataBoundConstraint By(string value, string binding)
        {
            return new DataBoundConstraint(value, binding);
        }

        public class DataBoundConstraint : By
        {
            public DataBoundConstraint(string value, string knockoutParameter = "value")
            {
                string bindingExprWithSpace = knockoutParameter + ": " + value;
                string bindingExprWithoutSpace = knockoutParameter + ":" + value;

                FindElementMethod = context =>
                {
                    try
                    {
                        return context.FindElement(CssSelector(string.Format("[data-bind*=\"{0}\"]", bindingExprWithSpace)));
                    }
                    catch (NoSuchElementException)
                    {
                        return context.FindElement(CssSelector(string.Format("[data-bind*=\"{0}\"]", bindingExprWithoutSpace)));
                    }
                };

                FindElementsMethod = context =>
                {
                    try
                    {
                        ReadOnlyCollection<IWebElement> result = context.FindElements(CssSelector(string.Format("[data-bind*=\"{0}\"]", bindingExprWithSpace)));

                        if (result.Count > 0)
                            return result;
                    }
                    catch (NoSuchElementException)
                    {}

                    return context.FindElements(CssSelector(string.Format("[data-bind*=\"{0}\"]", bindingExprWithoutSpace)));
                };
            }
        }
    }
}