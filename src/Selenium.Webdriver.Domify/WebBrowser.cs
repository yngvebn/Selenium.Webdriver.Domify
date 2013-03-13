using System;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace Selenium.Webdriver.Domify
{
    public static class WebBrowser
    {

        /// <summary>
        /// Shortcut to Current.Page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCurrentPage<T>(this Document document) where T : Page, new()
        {
            return document.Page<T>();
        }

        /// <summary>
        /// Browses to the given Page with the current browser window
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GoTo<T>(this Document document) where T : Page, new()
        {
            var navigationInfo = TryGetPageDescriptionAttribute<T>();

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException("You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static void GoToPageUrl(this Document document, Uri relativeUrl)
        {
            document.GoTo(relativeUrl.ToString());
        }

        /// <summary>
        /// Browses to the given Page with the current browser window
        /// </summary>
        public static object GoTo(this Document document, Type t)
        {
            var navigationInfo = TryGetPageDescriptionAttribute(t);

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException("You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");
            MethodInfo method = typeof(WebBrowser).GetMethod("GetCurrentPage");
            MethodInfo genericMethod = method.MakeGenericMethod(t);
            return genericMethod.Invoke(null, null);

        }

        public static T GoTo<T>(this Document document, string appendToUrl) where T : Page, new()
        {
            var navigationInfo = TryGetPageDescriptionAttribute<T>();

            if (navigationInfo != null)
                document.GoToPageUrl(Build(navigationInfo.Url, appendToUrl));
            else
                throw new InvalidOperationException("You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static Uri Build(Uri url, string appendToUrl)
        {
            Uri uri = new Uri(url + appendToUrl);
            return uri;
        }

        public static bool IsAtPage<T>(this Document document) where T : Page, new()
        {
            return document.IsAtPage(typeof(T));
        }

        public static bool IsAtPage(this Document document, Type pageType)
        {
            var navigationInfo = TryGetPageDescriptionAttribute(pageType);

            if (navigationInfo == null)
                throw new InvalidOperationException("The page type does not specify its uri");

            return String.Equals(navigationInfo.Url.ToString(), document.Uri.AbsolutePath, StringComparison.InvariantCultureIgnoreCase);
        }


        private static PageDescriptionAttribute TryGetPageDescriptionAttribute(Type t)
        {
            var customAttributes = t.GetCustomAttributes(true);

            foreach (var customAttribute in customAttributes)
            {
                var navigationInfo = customAttribute as PageDescriptionAttribute;

                if (navigationInfo != null)
                    return navigationInfo;
            }

            return null;
        }

        private static PageDescriptionAttribute TryGetPageDescriptionAttribute<T>()
        {
            return TryGetPageDescriptionAttribute(typeof(T));
        }


    }
}