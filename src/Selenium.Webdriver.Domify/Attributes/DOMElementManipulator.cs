using System;

namespace Selenium.Webdriver.Domify.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DOMElementManipulatorAttribute : Attribute
    {
        public string Property { get; set; }
        public string Tag { get; set; }
        public string Type { get; set; }

        internal DOMElementManipulatorAttribute(string property, string tag)
        {
            Property = property;
            Tag = tag;
        }

        public bool CanManipulate(DOMElementAttribute attribute)
        {
            var canManipulate = attribute.Tag.Equals(Tag, StringComparison.CurrentCultureIgnoreCase);
            if (!string.IsNullOrEmpty(Type)) return (attribute.Type ?? "").Equals(Type, StringComparison.CurrentCultureIgnoreCase);
            return canManipulate;
        }
    }
}