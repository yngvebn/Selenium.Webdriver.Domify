using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Attributes;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Elements
{
    [TestFixture]
    public class GetAllElements : BrowserScenario
    {
        [Test, TestCaseSource(typeof(ElementTestCaseData), "GetElements")]
        public void GetElementPage(ElementWithDomAttribute element)
        {

            string tag = element.Attribute.Tag;
            string type = element.Attribute.Type ?? "";

            Document.Navigation.GoTo<GenericElementPage>(new { tag = tag, type = type, text = "Some element text", id = "element_id" });
            TheElementShouldExists("element_id", element.Element);

            WeShouldFindTheElementOnTheCurrentPage("element_id", element.Element);
            WeShouldFindTheElementOnTheCurrentPageAsSingleElement("element_id", element.Element);

        }

        private void TheElementShouldExists(string elementId, Type element)
        {
            Assert.That(Document.Exists(elementId), Is.True);
        }

        private void WeShouldFindTheElementOnTheCurrentPageAsSingleElement(string elementId, Type element)
        {
            dynamic el = typeof (WebElementExtensions).GetMethods().Where(d => d.GetParameters().Any(c => c.ParameterType == typeof (string)) && d.GetParameters().Count() == 2).Single(m => m.ReturnType == element).Invoke(null, new object[] {Document, elementId});
            Assert.That(el.GetType(), Is.EqualTo(element));
        }

        private void WeShouldFindTheElementOnTheCurrentPage(string elementId, Type elementType)
        {
            dynamic elements = typeof(WebElementExtensions).GetMethods().Where(d => d.GetParameters().Any(c => c.ParameterType == typeof(By)) && d.GetParameters().Count() == 2).Single(m => m.Name.Equals("Find") && m.ReturnType.Name.Equals("IList`1")).MakeGenericMethod(elementType).Invoke(null, new object[] {Document,  By.Id(elementId) });

            var singleElement = elements[0];
            Assert.That(singleElement.GetType(), Is.EqualTo(elementType));
        }


        protected override void Given()
        {
        }

        protected override void When()
        {
        }
    }

    public class ElementWithDomAttribute
    {
        public Type Element { get; set; }
        public DOMElementAttribute Attribute { get; set; }
    }

    public class ElementTestCaseData
    {
        
        public IEnumerable<TestCaseData> GetElements()
        {
            foreach (var element in typeof(H1).Module.GetTypes().Where(t => t.BaseType == typeof(WebElement)))
            {
                if (
                   element == typeof(Option) ||
                   element == typeof(TBody) ||
                   element == typeof(TR) ||
                   element == typeof(TD) ||
                   element == typeof(TH) ||
                   element == typeof(HtmlElement) ||
                   element == typeof(THead) || element == typeof (Head) ||
                    element == typeof(Meta) || element == typeof(Link) || element == typeof(Style) ||
                     element == typeof(Script) ||
                    element == typeof (Base) ||
                 element == typeof(LI))
                {
                    continue;
                }
                
                foreach (var att in GetDomElementAttribute(element))
                {
                    yield return new TestCaseData(new ElementWithDomAttribute(){
                        Attribute = att, Element = element
                        });
                }
            }


        }

        private IEnumerable<DOMElementAttribute> GetDomElementAttribute(Type type)
        {
            foreach (var att in type.GetCustomAttributes(typeof(DOMElementAttribute), false).Cast<DOMElementAttribute>())
            {
                
                if (att is HEADElementAttribute) continue;
                
                yield return att;
            }
        }
    }
}