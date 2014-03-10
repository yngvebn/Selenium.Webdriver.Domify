using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.Factories;

namespace Selenium.Webdriver.Domify.Cache
{
    internal static class CacheHolder
    {

        
        internal static Func<IWebElement, bool> GetFilterPredicate<T>(bool nocache = false)
           where T : WebElement
        {
            if (nocache) LocalFilterPredicateCache.Remove(typeof (T));
            if (LocalFilterPredicateCache.ContainsKey(typeof(T))) return LocalFilterPredicateCache[typeof(T)];

            var filterPredicate = DOMElementFilterFactory.Get<T>();
            LocalFilterPredicateCache.Add(typeof(T), filterPredicate);
            return filterPredicate;
        }

        private static Dictionary<Type, Func<IWebElement, bool>> _localFilterPredicateCache;
        private static Dictionary<Type, Func<IWebElement, bool>> LocalFilterPredicateCache
        {
            get
            {
                if (_localFilterPredicateCache == null) _localFilterPredicateCache = new Dictionary<Type, Func<IWebElement, bool>>();
                return _localFilterPredicateCache;
            }
        }

        private static Dictionary<Type, PageDescriptionAttribute> _pageDescriptionAttribute;
        private static Dictionary<Type, PageDescriptionAttribute> PageDescriptionAttribute
        {
            get
            {
                if (_pageDescriptionAttribute == null) _pageDescriptionAttribute = new Dictionary<Type, PageDescriptionAttribute>();
                return _pageDescriptionAttribute;
            }
        }

        public static PageDescriptionAttribute TryGetPageDescriptionAttribute(Assembly containingAssembly, string pageTitle)
        {
            var att = PageDescriptionAttribute.Any(c => c.Value.Title.Equals(pageTitle));
            if (att) return PageDescriptionAttribute.Single(c => c.Value.Title.Equals(pageTitle)).Value;

            var pages = containingAssembly.GetTypes().Where(t => t.BaseType == typeof(Page));
            var page = pages.SingleOrDefault(p => p.GetCustomAttribute<PageDescriptionAttribute>().Title.Equals(pageTitle));
            return TryGetPageDescriptionAttribute(page);
        }

        public static PageDescriptionAttribute TryGetPageDescriptionAttribute(Type t)
        {

            if (PageDescriptionAttribute.ContainsKey(t)) return PageDescriptionAttribute[t];

            var customAttributes = t.GetCustomAttributes(true);
            PageDescriptionAttribute navigationInfo = null;
            foreach (var customAttribute in customAttributes)
            {
                navigationInfo = customAttribute as PageDescriptionAttribute;

                if (navigationInfo != null)
                {
                    PageDescriptionAttribute.Add(t, navigationInfo);
                    break;
                }
            }

            return navigationInfo;
        }

    }
}