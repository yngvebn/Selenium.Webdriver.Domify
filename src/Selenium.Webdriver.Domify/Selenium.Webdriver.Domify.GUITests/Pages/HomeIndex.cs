using System;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("Index", "http://localhost:31337/Home/Index")]
    public class HomeIndex: Page
    {
        public TextField TextBox
        {
            get { return Document.TextField("textbox"); }
        }

        public TextField DelayedTextBox
        {
            get { return Document.TextField("delayedtextbox"); }
        }
        public TextField KnockoutTextBox
        {
            get { return Document.TextField(Knockout.ByValue("someValue")); }
        }

    }
}