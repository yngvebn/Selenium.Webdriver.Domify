using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.Webdriver.Domify.Elements;


namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Index", "http://localhost:31338/Home/Index")]
    public class HomeIndex : Page
    {

        [FindsBy(Using = "textbox", How = How.Id)]
        public virtual TextField TextBox { get; set; }

        [FindsBy(Using="dateTimeField", How = How.Id)]
        public virtual DateField DateBox { get; set; }

        public TextField DelayedTextBox
        {
            get { return Document.TextField("delayedtextbox"); }
        }
        public TextField KnockoutTextBox
        {
            get { return Document.TextField(Knockout.ByValue("text")); }
        }

        public HyperLink DelayedLink
        {
            get { return Document.WaitUntilFound<HyperLink>(By.Id("someLink")); }
        }

        public Span KnockoutSpan
        {
            get { return Document.Span(Knockout.ByText("text")); }
        }

        public TextField TextBoxWithoutId
        {
            get { return Document.TextField(By.ClassName("textboxwithoutid")); }

        }

        public InputFile InputFile
        {
            get { return Document.FileUpload("file"); }
        }

        public UL NestedList
        {
            get { return Document.List("nestedList"); }
        }

        public UL NestedKnockoutList
        {
            get { return Document.List(Knockout.ByForeach("knockoutlist")); }
        }

        public Button InvisibleButton { get { return Document.Button("invisible"); } }
    }
}