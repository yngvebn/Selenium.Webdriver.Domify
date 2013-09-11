using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.Cache
{
    internal static class CacheHolder
    {

        
        internal static Func<IWebElement, bool> GetFilterPredicate<T>(bool nocache = false)
           where T : BaseWebElement
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


        public static PageDescriptionAttribute TryGetPageDescriptionAttribute(Type t)
        {

            if (PageDescriptionAttribute.ContainsKey(t)) return PageDescriptionAttribute[t];

            var customAttributes = t.GetCustomAttributes(true);

            foreach (var customAttribute in customAttributes)
            {
                var navigationInfo = customAttribute as PageDescriptionAttribute;

                if (navigationInfo != null)
                {
                    PageDescriptionAttribute.Add(t, navigationInfo);
                    return navigationInfo;
                }
            }

            return null;
        }

    }
}