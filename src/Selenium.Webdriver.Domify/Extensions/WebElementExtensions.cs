using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Cache;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public static class WebElementExtensions
    {
        public static Button Button(this ISearchContext context, string id)
        {
            return context.Button(By.Id(id));
        }

        public static Button Button(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Button>(constraint).SingleOrThrowNotFoundException();
        }

        public static IList<Button> Buttons(this ISearchContext context, OpenQA.Selenium.By constraint = null)
        {
            return context.Find<Button>(constraint);
        }

        public static Fieldset Fieldset(this ISearchContext context, string id)
        {
            return context.Fieldset(By.Id(id));
        }


        public static Fieldset Fieldset(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Fieldset>(constraint).SingleOrThrowNotFoundException();
        }

        public static IList<Fieldset> Fieldsets(this ISearchContext context, OpenQA.Selenium.By constraint = null)
        {
            return context.Find<Fieldset>(constraint);
        }


        public static CheckBox CheckBox(this ISearchContext context, string id)
        {
            return context.CheckBox(By.Id(id));
        }

        public static CheckBox CheckBox(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<CheckBox>(constraint).SingleOrThrowNotFoundException();
        }

        public static DateField DateField(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<DateField>(constraint).SingleOrThrowNotFoundException();
        }

        public static DateField DateField(this ISearchContext context, string id)
        {
            return context.DateField(By.Id(id));
        }

        public static Div Div(this ISearchContext context, string id)
        {
            return context.Div(By.Id(id));
        }

        public static Div Div(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Div>(constraint).SingleOrThrowNotFoundException();
        }

        public static IList<Div> Divs(this ISearchContext context, OpenQA.Selenium.By constraint = null)
        {
            return context.Find<Div>(constraint);
        }

        public static bool Exists(this ISearchContext context, string id)
        {
            return context.FindElements(By.Id(id)).Count > 0;
        }

        public static bool Exists(this ISearchContext context, By predicate)
        {
            return context.FindElements(predicate).Count > 0;
        }

        public static bool Exists<T>(this IWebElement context, Func<IWebElement, T> func) where T : BaseWebElement
        {
            try
            {
                return func(context) != null;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        public static Form Form(this ISearchContext context, string id)
        {
            return context.Form(By.Id(id));
        }

        public static Form Form(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Form>(constraint).SingleOrThrowNotFoundException();
        }

        public static H2 H2(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<H2>(constraint).SingleOrThrowNotFoundException();
        }

        public static H2 H2(this ISearchContext context, string id)
        {
            return context.H2(By.Id(id));
        }

        public static H1 H1(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<H1>(constraint).SingleOrThrowNotFoundException();
        }

        public static H1 H1(this ISearchContext context, string id)
        {
            return context.H1(By.Id(id));
        }

        public static H3 H3(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<H3>(constraint).SingleOrThrowNotFoundException();
        }

        public static H3 H3(this ISearchContext context, string id)
        {
            return context.H3(By.Id(id));
        }

        public static string InnerHtml(this IWebElement element)
        {
            return element.Text;
        }

        public static Input Input(this ISearchContext context, string id)
        {
            return context.Input(By.Id(id));
        }

        public static Input Input(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Input>(constraint).SingleOrThrowNotFoundException();
        }


        public static bool IsVisible(this BaseWebElement element)
        {
            if (!element.Displayed)
                return false;

            return element.Style.Display != "none";
        }


        public static HyperLink Link(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<HyperLink>(constraint).SingleOrThrowNotFoundException();
        }

        public static HyperLink Link(this ISearchContext context, string id)
        {
            return context.Link(By.Id(id));
        }

        public static UL List(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<UL>(constraint).SingleOrThrowNotFoundException();
        }

        public static UL List(this ISearchContext context, string id)
        {
            return context.List(By.Id(id));
        }

        public static FileUpload FileUpload(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<FileUpload>(constraint).SingleOrThrowNotFoundException();
        }

        public static FileUpload FileUpload(this ISearchContext context, string id)
        {
            return context.FileUpload(By.Id(id));
        }


        public static LI ListItem(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<LI>(constraint).SingleOrThrowNotFoundException();
        }

        public static P P(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<P>(constraint).SingleOrThrowNotFoundException();
        }

        public static RadioButton RadioButton(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<RadioButton>(constraint).SingleOrThrowNotFoundException();
        }

        public static RadioButton RadioButton(this ISearchContext context, string id)
        {
            return context.RadioButton(By.Id(id));
        }


        public static TableCell TableCell(this ISearchContext context, string id)
        {
            return context.TableCell(By.Id(id));
        }

        public static TableCell TableCell(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<TableCell>(constraint).SingleOrThrowNotFoundException();
        }


        public static SelectList SelectList(this ISearchContext context, string id)
        {
            return context.SelectList(By.Id(id));
        }

        public static SelectList SelectList(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<SelectList>(constraint).SingleOrThrowNotFoundException();
        }

        public static IList<SelectListItem> SelectListItems(this ISearchContext context, OpenQA.Selenium.By constraint = null)
        {
            return context.Find<SelectListItem>(constraint).ToList();
        }

        public static Span Span(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Span>(constraint).SingleOrThrowNotFoundException();
        }

        public static Span Span(this ISearchContext context, string id)
        {
            return context.Span(By.Id(id));
        }

        public static TH TH(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<TH>(constraint).SingleOrThrowNotFoundException();
        }

        public static Table Table(this ISearchContext element, string id)
        {
            return element.Table(By.Id(id));
        }

        public static Table Table(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<Table>(constraint).SingleOrThrowNotFoundException();
        }

        public static TableBody TableBody(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<TableBody>(constraint).SingleOrThrowNotFoundException();
        }

        public static TextArea TextArea(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<TextArea>(constraint).SingleOrThrowNotFoundException();
        }

        public static TextArea TextArea(this ISearchContext context, string id)
        {
            return context.TextArea(By.Id(id));
        }

        public static TextField TextField(this ISearchContext context, OpenQA.Selenium.By constraint)
        {
            return context.Find<TextField>(constraint).SingleOrThrowNotFoundException();
        }

        public static TextField TextField(this ISearchContext context, string id)
        {
            return context.TextField(By.Id(id));
        }

        public static void WaitUntil<T>(this T element, Predicate<T> predicate, TimeSpan timeOut = default(TimeSpan), Type[] ignoredExceptionTypes = null)
        {
            if (timeOut == default(TimeSpan))
                timeOut = TimeSpan.FromSeconds(30);

            TimeoutManager.Execute(timeOut, predicate, element, ignoredExceptionTypes);
        }

        private static TSource SingleOrThrowNotFoundException<TSource>(this IEnumerable<TSource> source) where TSource : class
        {
            TSource found = source.SingleOrDefault();

            if (found == null)
                throw new NotFoundException();

            return found;
        }

        public static T Find<T>(this ISearchContext context, string id)
           where T : BaseWebElement
        {
            return context.Find<T>(By.Id(id)).SingleOrDefault();
        }

        public static IList<T> Find<T>(this ISearchContext context, bool deep = true)
              where T : BaseWebElement
        {
            return deep ? GetByXPath<T>(context) : GetByCSS<T>(context);
        }

        private static IList<T> GetByCSS<T>(ISearchContext context)
            where T : BaseWebElement
        {
            string css = "";
            var element = (WebElement) context;
            var id = string.IsNullOrEmpty(element.Id) ?  element.GenerateIdForElement() : element.Id;
            foreach(var expr in DOMElementCssFactory.Get<T>())
            {
                css += string.Format(":root #{0} > {1}, ", id, expr);
            }
            css = css.TrimEnd(',', ' ');
            return context.Find<T>(By.CssSelector(css));
        }

        private static IList<T> GetByXPath<T>(ISearchContext context)
             where T : BaseWebElement
        {
            string xPath = "";
            string start = ".//";
            foreach (var expr in DOMElementXPathFactory.Get<T>())
            {
                xPath += string.Format("{1}{0} | ", expr, start);
            }
            xPath = "(" + xPath.TrimEnd(' ', '|') + ")";
            Func<IWebElement, T> create = element => typeof(T).GetMethod("Create").Invoke(null, new object[] { element }) as T;


            return context.FindElements(OpenQA.Selenium.By.XPath(xPath)).Select(create).ToList();
        }

        private static IList<T> Find<T>(this ISearchContext context, By by, bool nocache)
            where T : BaseWebElement
        {
            var filterPredicate = CacheHolder.GetFilterPredicate<T>();

            if (filterPredicate == null)
            {
                throw new InvalidOperationException("Unable to look for elements of type " + typeof(T));
            }

            Func<IWebElement, T> create = element => typeof(T).GetMethod("Create").Invoke(null, new object[] { element }) as T;

            IEnumerable<IWebElement> elements;

            if (by != null)
            {
                elements = context.FindElements(by).Where(filterPredicate);
            }
            else
            {
                var webElement = context as WebElement;
                by = By.XPath("//*");
                if (webElement != null)
                {
                    by = By.XPath(webElement.GetElementXPath() + "//*");
                }
                elements = context.FindElements(by).Where(filterPredicate);
            }
            return elements.Select(create).ToList();
        }

        public static IList<T> Find<T>(this ISearchContext context, OpenQA.Selenium.By by)
            where T : BaseWebElement
        {
            try
            {
                return context.Find<T>(by, false);
            }
            catch (StaleElementReferenceException)
            {
                return context.Find<T>(by, true);
            }
        }


    }

}