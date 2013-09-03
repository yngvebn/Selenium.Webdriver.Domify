using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
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

        private T GetAttribute<T>(Type element)
        {
            return element.GetCustomAttributes(typeof(T), false).Cast<T>().FirstOrDefault();
        }
    }

    public class ElementTestCaseData
    {

        public IEnumerable<TestCaseData> GetElements()
        {
            foreach(var types in typeof(H1).Module.GetTypes().Where(t => t.BaseType == typeof(WebElement)))
            {
                yield return new TestCaseData(types);
            }

            
        }
    }
}