using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    public class CombineByWithTag : By
    {
        public CombineByWithTag(string tagName, By @base)
        {
            FindElementMethod = context =>
                {
                    foreach (var findElement in @base.FindElements(context))
                    {
                        if (string.Equals(findElement.TagName, tagName, StringComparison.InvariantCultureIgnoreCase))
                            return findElement;
                    }

                    throw new NotFoundException();
                };

            FindElementsMethod = context =>
                {
                    var result = new List<IWebElement>();

                    foreach (var findElement in @base.FindElements(context))
                    {
                        if (string.Equals(findElement.TagName, tagName, StringComparison.InvariantCultureIgnoreCase))
                            result.Add(findElement);
                    }

                    return result.AsReadOnly();
                };
        }
    }
}