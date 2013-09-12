using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.Unittests
{
    [TestFixture]
    public class DOMElementAttributeTests
    {
        [Test, TestCaseSource(typeof(ElementTestCaseData), "GetElements")]
        public void AllElementsMustHaveDOMElementAttribute(Type element)
        {
            var attribute = GetAttribute<DOMElementAttribute>(element);
            Assert.That(attribute, Is.Not.Null, string.Format("{0} is missing required DOMElementAttribute", element.Name));
            Assert.That(attribute.Tag, Is.Not.Empty, string.Format("Tagname cannot be empty ({0})", element.Name));
        }

        [Test, TestCaseSource(typeof(ElementTestCaseData), "GetElements")]
        public void DocumentShouldImplementAllElementsAccessors(Type element)
        {
            // ignore elements that are obsolete or requires a parent.
            if (element == typeof(Body) ||
                  element == typeof(Option) ||
                  element == typeof(TBody) ||
                  element == typeof(TR) ||
                  element == typeof(TD) ||
                  element == typeof(TH) ||
                  element == typeof(THead) ||
                element == typeof(LI)) Assert.Ignore("Body and Element does not count.");


            var type = typeof(IListWebElements);
            var listType = typeof(IList<>).MakeGenericType(element);
            var method = type.GetMethods().SingleOrDefault(t => t.ReturnType == listType);
            Assert.That(method, Is.Not.Null, string.Format("IListWebElements doesn't have method to list {0}", element));
        }

        private T GetAttribute<T>(Type element)
        {
            return element.GetCustomAttributes(typeof(T), false).Cast<T>().FirstOrDefault();
        }
    }

    public class ElementTestCaseData
    {

        public IEnumerable<TestCaseData> GetElements()
        {
            foreach (var types in typeof(H1).Module.GetTypes().Where(t => t.BaseType == typeof(WebElement)))
            {
                yield return new TestCaseData(types);
            }


        }
    }
}