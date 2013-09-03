using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public static class WebElementExtensions
    {
        public static Button Button(this ISearchContext driver, string id)
        {
            return driver.Button(By.Id(id));
        }

        public static Button Button(this ISearchContext driver, By constraint)
        {
            IWebElement button = driver.FindElements(new CombineByWithTag("button", constraint))
                                       .Union(FindInputsOfType(driver, constraint, "button"))
                                       .Union(FindInputsOfType(driver, constraint, "submit"))
                                       .SingleOrThrowNotFoundException();

            return Elements.Button.Create(button);
        }

        public static Button Button(this ISearchContext driver, ByFirst constraint)
        {
            return Elements.Button.Create(driver.FindElement(By.CssSelector("button")));
        }

        public static CheckBox CheckBox(this ISearchContext driver, string id)
        {
            return driver.CheckBox(By.Id(id));
        }

        public static CheckBox CheckBox(this ISearchContext driver, By constraint)
        {
            return Elements.CheckBox.Create(FindInputsOfType(driver, constraint, "checkbox").SingleOrThrowNotFoundException());
        }

        public static DateField DateField(this ISearchContext driver, By constraint)
        {
            return Elements.DateField.Create(FindInputsOfType(driver, constraint, "date").SingleOrThrowNotFoundException());
        }

        public static DateField DateField(this ISearchContext driver, string id)
        {
            return driver.DateField(By.Id(id));
        }

        public static Div Div(this ISearchContext driver, string id)
        {
            return driver.Div(By.Id(id));
        }

        public static Div Div(this ISearchContext driver, By constraint)
        {
            return Elements.Div.Create(driver.FindElement(new CombineByWithTag("div", constraint)));
        }

        public static Div Div(this ISearchContext driver, ByFirst constraint)
        {
            return Elements.Div.Create(driver.FindElement(By.TagName("div")));
        }


        public static IList<Div> Divs(this ISearchContext context)
        {
            return context.FindElements(By.TagName("div")).Select(Elements.Div.Create).ToList();
        }

         public static IList<T> Find<T> (this IDocument driver, By by = null)
            where T: WebElement
        {
            string tagName = GetElementTagNameFromDefinition(typeof (T));
            if(string.IsNullOrEmpty(tagName))
            {
                throw new InvalidOperationException("Unable to look for elements of type "+typeof(T));
            }
             Func<IWebElement, T> create = element => typeof (T).GetMethod("Create").Invoke(null, new object[] {element}) as T;
             By byExpression = By.TagName(tagName);

             return driver.FindElements(byExpression).Select(create).ToList();
        }


         private static string GetElementTagNameFromDefinition(Type type)
         {
             var attribute = type.GetCustomAttributes(typeof(DOMElementAttribute), false).Cast<DOMElementAttribute>().SingleOrDefault();
             if (attribute != null)
             {
                 return attribute.Tag;
             }
             return string.Empty;
         }

        public static IList<Div> Divs(this ISearchContext context, By by)
        {
            return context.FindElements(new CombineByWithTag("div", @by)).Select(Elements.Div.Create).ToList();
        }

        public static bool Exists(this ISearchContext driver, string id)
        {
            return driver.FindElements(By.Id(id)).Count > 0;
        }

        public static bool Exists(this ISearchContext driver, By predicate)
        {
            return driver.FindElements(predicate).Count > 0;
        }

        public static bool Exists<T>(this IWebElement driver, Func<IWebElement, T> func) where T : WebElement
        {
            try
            {
                return func(driver) != null;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        public static Form Form(this ISearchContext driver, string id)
        {
            return driver.Form(By.Id(id));
        }

        public static Form Form(this ISearchContext driver, By constraint)
        {
            return Elements.Form.Create(driver.FindElement(new CombineByWithTag("form", constraint)));
        }

        public static Form Form(this ISearchContext driver, ByFirst constraint)
        {
            return Elements.Form.Create(driver.FindElement(By.TagName("form")));
        }

        

        public static H2 H2(this ISearchContext driver, By constraint)
        {
            return Elements.H2.Create(driver.FindElement(new CombineByWithTag("h2", constraint)));
        }

        public static H2 H2(this ISearchContext driver, string id)
        {
            return driver.H2(By.Id(id));
        }

        public static H1 H1(this ISearchContext driver, By constraint)
        {
            return Elements.H1.Create(driver.FindElement(new CombineByWithTag("h1", constraint)));
        }

        public static H1 H1(this ISearchContext driver, string id)
        {
            return driver.H1(By.Id(id));
        }


        public static H3 H3(this ISearchContext driver, By constraint)
        {
            return Elements.H3.Create(driver.FindElement(new CombineByWithTag("h3", constraint)));
        }

        public static H3 H3(this ISearchContext driver, string id)
        {
            return driver.H3(By.Id(id));
        }

        public static string InnerHtml(this IWebElement element)
        {
            return element.Text;
        }

        public static Input Input(this ISearchContext driver, string id)
        {
            return Elements.Input.Create(driver.FindElement(By.Id(id)));
        }

        public static Input Input(this ISearchContext driver, By constraint)
        {
            return Elements.Input.Create(driver.FindElement(new CombineByWithTag("input", constraint)));
        }

        public static Input Input(this ISearchContext driver, ByFirst constraint)
        {
            return Elements.Input.Create(driver.FindElement(By.CssSelector("input")));
        }

        public static bool IsVisible(this IWebElement element)
        {
            if (!element.Displayed)
                return false;

            return element.GetCssValue("display") != "none";
        }

        public static HyperLink Link(this ISearchContext driver, ByFirst byFirst)
        {
            return HyperLink.Create(driver.FindElement(By.CssSelector("a")));
        }

        public static HyperLink Link(this ISearchContext driver, By constraint)
        {
            return HyperLink.Create(driver.FindElement(new CombineByWithTag("a", constraint)));
        }

        public static HyperLink Link(this ISearchContext driver, string id)
        {
            return driver.Link(By.Id(id));
        }

        public static UL List(this ISearchContext driver, By constraint)
        {
            return UL.Create(driver.FindElement(new CombineByWithTag("ul", constraint)));
        }

        public static UL List(this ISearchContext driver, ByFirst constraint)
        {
            return UL.Create(driver.FindElement(By.CssSelector("ul")));
        }

        public static UL List(this ISearchContext driver, string id)
        {
            return driver.List(By.Id(id));
        }

        public static FileUpload FileUpload(this ISearchContext driver, By constraint)
        {
            return Elements.FileUpload.Create(driver.FindElement(constraint));
        }

        public static FileUpload FileUpload(this ISearchContext driver, string id)
        {
            return driver.FileUpload(By.Id(id));
        }


        public static LI ListItem(this ISearchContext driver, By constraint)
        {
            return LI.Create(driver.FindElement(new CombineByWithTag("li", constraint)));
        }

        public static P P(this ISearchContext driver, By constraint)
        {
            return Elements.P.Create(driver.FindElement(new CombineByWithTag("p", constraint)));
        }

        public static RadioButton RadioButton(this ISearchContext driver, By constraint)
        {
            return Elements.RadioButton.Create(driver.FindElement(constraint));
        }

        public static RadioButton RadioButton(this ISearchContext driver, string id)
        {
            return driver.RadioButton(By.Id(id));
        }

        public static SelectList SelectList(this ISearchContext driver, string id)
        {
            return driver.SelectList(By.Id(id));
        }

        public static SelectList SelectList(this ISearchContext driver, By constraint)
        {
            return Elements.SelectList.Create(driver.FindElement(new CombineByWithTag("select", constraint)));
        }

        public static Span Span(this ISearchContext context, By constraint)
        {
            return Elements.Span.Create(context.FindElement(new CombineByWithTag("span", constraint)));
        }

        public static Span Span(this ISearchContext context, string id)
        {
            return context.Span(By.Id(id));
        }

        public static TH TH(this ISearchContext driver, By constraint)
        {
            return Elements.TH.Create(driver.FindElement(new CombineByWithTag("th", constraint)));
        }

        public static Table Table(this ISearchContext element, string id)
        {
            return element.Table(By.Id(id));
        }

        public static Table Table(this ISearchContext driver, By constraint)
        {
            return Elements.Table.Create(driver.FindElement(new CombineByWithTag("table", constraint)));
        }

        public static Table Table(this ISearchContext driver, ByFirst constraint)
        {
            return Elements.Table.Create(driver.FindElement(By.CssSelector("table")));
        }

        public static TableBody TableBody(this ISearchContext driver, By constraint)
        {
            return Elements.TableBody.Create(driver.FindElement(new CombineByWithTag("tbody", constraint)));
        }

        public static TextArea TextArea(this ISearchContext driver, By constraint)
        {
            return Elements.TextArea.Create(driver.FindElement(new CombineByWithTag("textarea", constraint)));
        }

        public static TextArea TextArea(this ISearchContext driver, string id)
        {
            return driver.TextArea(By.Id(id));
        }

        public static TextField TextField(this ISearchContext driver, By constraint)
        {
            IEnumerable<IWebElement> textFields = FindInputsOfType(driver, constraint, "text")
                .Union(FindInputsOfType(driver, constraint, "password"))
                .Union(driver.FindElements(new CombineByWithTag("textarea", constraint)));

            return Elements.TextField.Create(textFields.SingleOrThrowNotFoundException());
        }

        public static TextField TextField(this ISearchContext driver, string id)
        {
            return driver.TextField(By.Id(id));
        }

        public static void WaitUntil<T>(this T element, Predicate<T> predicate, TimeSpan timeOut = default(TimeSpan), Type[] ignoredExceptionTypes = null) 
        {
            if (timeOut == default(TimeSpan))
                timeOut = TimeSpan.FromSeconds(30);

            TimeoutManager.Execute(timeOut, predicate, element, ignoredExceptionTypes);
        }

        private static IEnumerable<IWebElement> FindInputsOfType(ISearchContext driver, By constraint, string type)
        {
            return driver.FindElements(new CombineByWithTag("input", constraint))
                         .Where(element => element.GetAttribute("type") == type);
        }

        private static TSource SingleOrThrowNotFoundException<TSource>(this IEnumerable<TSource> source) where TSource : class
        {
            TSource found = source.SingleOrDefault();

            if (found == null)
                throw new NotFoundException();

            return found;
        }
    }
}