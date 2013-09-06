using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.Web.Controllers
{
    public class ElementController : Controller
    {
        public ActionResult AllElements()
        {
            var elements = GetElements().SelectMany(t => GetAttributes<DOMElementAttribute>(t)).Where(t => t.Tag != "*")
                .Select(CreateHtmlElementModel).ToList();


            return View(elements);
        }

        private HtmlElementModel CreateHtmlElementModel(DOMElementAttribute att)
        {

            List<AttributeViewModel> attributes = new List<AttributeViewModel>();
            if (!string.IsNullOrEmpty(att.Type))
            {
                attributes.Add(new AttributeViewModel("type", att.Type));
            }
            string text = "";
            if (NonSelfClosingTags.Contains(att.Tag.ToLower()))
            {
                text = "This is a " + att.Tag;
            }
            return new HtmlElementModel(att.Tag, attributes.ToArray(), text);
        }

        private IEnumerable<T> GetAttributes<T>(Type element)
        {
            return element.GetCustomAttributes(typeof(T), false).Cast<T>();
        }
        public IEnumerable<Type> GetElements()
        {
            foreach (var types in typeof(H1).Module.GetTypes().Where(t => t.BaseType == typeof(WebElement)))
            {
                yield return types;
            }
        }

        public string[] NonSelfClosingTags
        {
            get { return ReadFileWithTags().ToArray(); }
        }

        private IEnumerable<string> ReadFileWithTags()
        {
            using (var sr = new StreamReader(Server.MapPath("~/app_data/tags.txt")))
            {
                while(!sr.EndOfStream)
                yield return sr.ReadLine();
            }
        }
    }

    public class HtmlElementModel
    {
        public string TagName { get; set; }
        public AttributeViewModel[] Attributes { get; set; }
        public string Text { get; set; }
        public HtmlElementModel(string tagName, AttributeViewModel[] attributes, string text = null)
        {
            TagName = tagName;
            Attributes = attributes;
            Text = text;
        }
    }

    public class AttributeViewModel
    {
        public AttributeViewModel()
        {

        }
        public AttributeViewModel(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}