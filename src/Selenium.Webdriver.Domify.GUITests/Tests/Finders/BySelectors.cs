using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests.Tests.Finders
{
    [TestFixture]
    public class BySelectors
    {
        public BySelectors()
        {
            
        }
        public IDocument Document
        {
            get { return BrowserTestSettings.Driver.Document(); }
        }

        private Page _currentPage;


        [TestCase("css-button", typeof(Button))]
        [TestCase("css-checkbox", typeof(CheckBox))]
        [TestCase("css-color", typeof(ColorInput))]
        [TestCase("css-date", typeof(DateField))]
        [TestCase("css-datetime", typeof(TextField))]
        [TestCase("css-datetime-local", typeof(TextField))]
        [TestCase("css-email", typeof(TextField))]
        [TestCase("css-file", typeof(FileUpload))]
        [TestCase("css-hidden", typeof(Hidden))]
        [TestCase("css-image", typeof(Button))]
        [TestCase("css-month", typeof(TextField))]
        [TestCase("css-number", typeof(TextField))]
        [TestCase("css-password", typeof(TextField))]
        [TestCase("css-radio", typeof(RadioButton))]
        [TestCase("css-range", typeof(Range))]
        [TestCase("css-reset", typeof(Button))]
        [TestCase("css-search", typeof(TextField))]
        [TestCase("css-submit", typeof(Button))]
        [TestCase("css-tel", typeof(TextField))]
        [TestCase("css-text", typeof(TextField))]
        [TestCase("css-time", typeof(TextField))]
        [TestCase("css-url", typeof(TextField))]
        [TestCase("css-week", typeof(TextField))]
        public void CorrectElementIsReturnedByCssClass(string cls, Type elementType)
        {
            _currentPage = Document.Navigation.GoTo<HtmlFormsWithCss>();
            dynamic item = typeof (WebElementExtensions).ExecuteStaticGenericMethod(elementType, "Find", Document, Find.ByClass(cls));
            Assert.That(item[0].GetType(), Is.SameAs(elementType));
        }

        [TestCase("id-button", typeof(Button))]
        [TestCase("id-checkbox", typeof(CheckBox))]
        [TestCase("id-color", typeof(ColorInput))]
        [TestCase("id-date", typeof(DateField))]
        [TestCase("id-datetime", typeof(TextField))]
        [TestCase("id-datetime-local", typeof(TextField))]
        [TestCase("id-email", typeof(TextField))]
        [TestCase("id-file", typeof(FileUpload))]
        [TestCase("id-hidden", typeof(Hidden))]
        [TestCase("id-image", typeof(Button))]
        [TestCase("id-month", typeof(TextField))]
        [TestCase("id-number", typeof(TextField))]
        [TestCase("id-password", typeof(TextField))]
        [TestCase("id-radio", typeof(RadioButton))]
        [TestCase("id-range", typeof(Range))]
        [TestCase("id-reset", typeof(Button))]
        [TestCase("id-search", typeof(TextField))]
        [TestCase("id-submit", typeof(Button))]
        [TestCase("id-tel", typeof(TextField))]
        [TestCase("id-text", typeof(TextField))]
        [TestCase("id-time", typeof(TextField))]
        [TestCase("id-url", typeof(TextField))]
        [TestCase("id-week", typeof(TextField))]
        public void CorrectElementIsReturnedById(string id, Type elementType)
        {
            _currentPage = Document.Navigation.GoTo<HtmlFormsWithId>();
            dynamic item = typeof(WebElementExtensions).ExecuteStaticGenericMethod(elementType, "Find", Document, By.Id(id));
            Assert.That(item[0].GetType(), Is.SameAs(elementType));
        }


        [TestCase("name-button", typeof(Button))]
        [TestCase("name-checkbox", typeof(CheckBox))]
        [TestCase("name-color", typeof(ColorInput))]
        [TestCase("name-date", typeof(DateField))]
        [TestCase("name-datetime", typeof(TextField))]
        [TestCase("name-datetime-local", typeof(TextField))]
        [TestCase("name-email", typeof(TextField))]
        [TestCase("name-file", typeof(FileUpload))]
        [TestCase("name-hidden", typeof(Hidden))]
        [TestCase("name-image", typeof(Button))]
        [TestCase("name-month", typeof(TextField))]
        [TestCase("name-number", typeof(TextField))]
        [TestCase("name-password", typeof(TextField))]
        [TestCase("name-radio", typeof(RadioButton))]
        [TestCase("name-range", typeof(Range))]
        [TestCase("name-reset", typeof(Button))]
        [TestCase("name-search", typeof(TextField))]
        [TestCase("name-submit", typeof(Button))]
        [TestCase("name-tel", typeof(TextField))]
        [TestCase("name-text", typeof(TextField))]
        [TestCase("name-time", typeof(TextField))]
        [TestCase("name-url", typeof(TextField))]
        [TestCase("name-week", typeof(TextField))]
        public void CorrectElementIsReturnedByName(string name, Type elementType)
        {
            _currentPage = Document.Navigation.GoTo<HtmlFormsWithNames>();
            dynamic item = typeof(WebElementExtensions).ExecuteStaticGenericMethod(elementType, "Find", Document, Find.ByName(name));
            Assert.That(item[0].GetType(), Is.SameAs(elementType));
        }

        [TestCase(0, typeof(Button))]
        [TestCase(1, typeof(CheckBox))]
        [TestCase(2, typeof(ColorInput))]
        [TestCase(3, typeof(DateField))]
        [TestCase(4, typeof(TextField))]
        [TestCase(5, typeof(TextField))]
        [TestCase(6, typeof(TextField))]
        [TestCase(7, typeof(FileUpload))]
        [TestCase(8, typeof(Hidden))]
        [TestCase(9, typeof(Button))]
        [TestCase(10, typeof(TextField))]
        [TestCase(11, typeof(TextField))]
        [TestCase(12, typeof(TextField))]
        [TestCase(13, typeof(RadioButton))]
        [TestCase(14, typeof(Range))]
        [TestCase(15, typeof(Button))]
        [TestCase(16, typeof(TextField))]
        [TestCase(17, typeof(Button))]
        [TestCase(18, typeof(TextField))]
        [TestCase(19, typeof(TextField))]
        [TestCase(20, typeof(TextField))]
        [TestCase(21, typeof(TextField))]
        [TestCase(22, typeof(TextField))]
        public void CorrectElementIsReturnedByIndex(int index, Type elementType)
        {
            _currentPage = Document.Navigation.GoTo<HtmlFormsWithId>();
            dynamic item = typeof(WebElementExtensions).ExecuteStaticGenericMethod(elementType, "Find", Document.Forms.First(), Find.ByIndex(index));
            Assert.That(item[0].GetType(), Is.SameAs(elementType));
        }

        [TestCase("css", "button", typeof(Button))]
        [TestCase("css", "checkbox", typeof(CheckBox))]
        [TestCase("css", "color", typeof(ColorInput))]
        [TestCase("css", "date", typeof(DateField))]
        [TestCase("css", "datetime", typeof(TextField))]
        [TestCase("css", "datetime-local", typeof(TextField))]
        [TestCase("css", "email", typeof(TextField))]
        [TestCase("css", "file", typeof(FileUpload))]
        [TestCase("css", "hidden", typeof(Hidden))]
        [TestCase("css", "image", typeof(Button))]
        [TestCase("css", "month", typeof(TextField))]
        [TestCase("css", "number", typeof(TextField))]
        [TestCase("css", "password", typeof(TextField))]
        [TestCase("css", "radio", typeof(RadioButton))]
        [TestCase("css", "range", typeof(Range))]
        [TestCase("css", "reset", typeof(Button))]
        [TestCase("css", "search", typeof(TextField))]
        [TestCase("css", "submit", typeof(Button))]
        [TestCase("css", "tel", typeof(TextField))]
        [TestCase("css", "text", typeof(TextField))]
        [TestCase("css", "time", typeof(TextField))]
        [TestCase("css", "url", typeof(TextField))]
        [TestCase("css", "week", typeof(TextField))]
        public void CorrectElementIsReturnedByClasses(string cls, string cls2, Type elementType)
        {
            _currentPage = Document.Navigation.GoTo<HtmlFormsWithMultipleCssClasses>();
            dynamic item = typeof(WebElementExtensions).ExecuteStaticGenericMethod(elementType, "Find", Document, Find.ByClasses(cls, cls2));
            Assert.That(item[0].GetType(), Is.SameAs(elementType));
        }

        [TestCase("button", typeof(Button))]
        [TestCase("checkbox", typeof(CheckBox))]
        [TestCase("color", typeof(ColorInput))]
        [TestCase("date", typeof(DateField))]
        [TestCase("datetime", typeof(TextField))]
        [TestCase("datetime-local", typeof(TextField))]
        [TestCase("email", typeof(TextField))]
        [TestCase("file", typeof(FileUpload))]
        [TestCase("hidden", typeof(Hidden))]
        [TestCase("image", typeof(Button))]
        [TestCase("month", typeof(TextField))]
        [TestCase("number", typeof(TextField))]
        [TestCase("password", typeof(TextField))]
        [TestCase("radio", typeof(RadioButton))]
        [TestCase("range", typeof(Range))]
        [TestCase("reset", typeof(Button))]
        [TestCase("search", typeof(TextField))]
        [TestCase("submit", typeof(Button))]
        [TestCase("tel", typeof(TextField))]
        [TestCase("text", typeof(TextField))]
        [TestCase("time", typeof(TextField))]
        [TestCase("url", typeof(TextField))]
        [TestCase("week", typeof(TextField))]
        public void CorrectElementIsReturnedByValue(string value, Type elementType)
        {
            _currentPage = Document.Navigation.GoTo<HtmlFormsWithValues>();
            dynamic item = typeof(WebElementExtensions).ExecuteStaticGenericMethod(elementType, "Find", Document, Find.ByValue(value));
            Assert.That(item[0].GetType(), Is.SameAs(elementType));
        }
    }

    public static class ReflectionExtensions
    {
        
        public static object ExecuteStaticGenericMethod(this Type objType, Type typeArgument, string method, params object[] arguments)
        {
            return objType.GetMethods().Where(d => d.GetParameters().Count() == 2).Single(m => m.Name.Equals(method) && m.ReturnType.Name.Equals("IList`1")).MakeGenericMethod(typeArgument).Invoke(null, arguments);
        }
    }
}
