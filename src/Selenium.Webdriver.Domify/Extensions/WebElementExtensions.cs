using System;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public static class WebElementExtensions
    {
        public static Button Button(this ISearchContext driver, string id)
        {
            return Elements.Button.Create(driver.Button(By.Id(id)));
        }

        public static Button Button(this ISearchContext driver, By constraint)
        {
            return Elements.Button.Create(driver.FindElement(constraint));
        }
        public static CheckBox CheckBox(this ISearchContext driver, string id)
        {
            return driver.CheckBox(By.Id(id));
        }

        public static CheckBox CheckBox(this ISearchContext driver, By constraint)
        {
            return Elements.CheckBox.Create(driver.FindElement(constraint));
        }
        public static Div Div(this ISearchContext driver, string id)
        {
            return driver.Div(By.Id(id));
        }

        public static Div Div(this ISearchContext driver, By constraint)
        {
            return Elements.Div.Create(driver.FindElement(constraint));
        }

        public static Form Form(this ISearchContext driver, string id)
        {
            return driver.Form(By.Id(id));
        }

        public static Form Form(this ISearchContext driver, By constraint)
        {
            return Elements.Form.Create(driver.FindElement(constraint));
        }

        public static H2 H2(this ISearchContext driver, By constraint)
        {
            return Elements.H2.Create(driver.FindElement(constraint));
        }

        public static H2 H2(this ISearchContext driver, string id)
        {
            return driver.H2(By.Id(id));
        }

        public static HyperLink Link(this ISearchContext driver, By constraint)
        {
            return HyperLink.Create(driver.FindElement(constraint));
        }

        public static HyperLink Link(this ISearchContext driver, string id)
        {
            return driver.Link(By.Id(id));
        }

        public static UL List(this ISearchContext driver, By constraint)
        {
            return UL.Create(driver.FindElement(constraint));
        }
        public static UL List(this ISearchContext driver, string id)
        {
            return driver.List(By.Id(id));
        }

        public static ListItem ListItem(this ISearchContext driver, By constraint)
        {
            return Elements.ListItem.Create(driver.FindElement(constraint));
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
            return Elements.SelectList.Create(driver.FindElement(constraint));
        }

        public static Span Span(this ISearchContext driver, By constraint)
        {
            return Elements.Span.Create(driver.FindElement(constraint));
        }

        public static Span Span(this ISearchContext driver, string id)
        {
            return driver.Span(By.Id(id));
        }

        public static Table Table(this ISearchContext element, string id)
        {
            return element.Table(By.Id(id));
        }

        public static Table Table(this ISearchContext driver, By constraint)
        {
            return Elements.Table.Create(driver.FindElement(constraint));
        }

        public static TableBody TableBody(this ISearchContext driver, By constraint)
        {
            return Elements.TableBody.Create(driver.FindElement(constraint));
        }

        public static TextField TextField(this ISearchContext driver, By constraint)
        {
            return Elements.TextField.Create(driver.FindElement(constraint));
        }

        public static TextField TextField(this ISearchContext driver, string id)
        {
            return driver.TextField(By.Id(id));
        }
        public static DateField DateField(this ISearchContext driver, By constraint)
        {
            return Elements.DateField.Create(driver.FindElement(constraint));
        }

        public static DateField DateField(this ISearchContext driver, string id)
        {
            return driver.DateField(By.Id(id));
        }
        public static Uri Uri(this IWebDriver webDriver)
        {
            return new Uri(webDriver.Url);
        }
    }
}