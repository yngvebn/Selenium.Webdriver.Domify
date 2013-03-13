using System;
using System.Reflection;

namespace Selenium.Webdriver.Domify
{
    public static class NavigationExtensions
    {
        public static T Page<T>(this INavigationService webDriver) where T : Page, new()
        {
            var t = new T { Document = webDriver.Document };
            return t;
        }
        

        /// <summary>
        /// Shortcut to Current.Page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCurrentPage<T>(this INavigationService document) where T : Page, new()
        {
            return document.Page<T>();
        }

        /// <summary>
        /// Browses to the given Page with the current browser window
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GoTo<T>(this INavigationService document) where T : Page, new()
        {
            var navigationInfo = TryGetPageDescriptionAttribute<T>();

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException("You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static void GoToPageUrl(this INavigationService document, Uri relativeUrl)
        {
            document.Document.Driver.Navigate().GoToUrl(relativeUrl);
        }

        /// <summary>
        /// Browses to the given Page with the current browser window
        /// </summary>
        public static void GoTo(this INavigationService document, Uri uri)
        {
            document.GoToPageUrl(uri);

        }

        /// <summary>
        /// Browses to the given Page with the current browser window
        /// </summary>
        public static object GoTo(this INavigationService document, Type t)
        {
            var navigationInfo = TryGetPageDescriptionAttribute(t);

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException("You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");
            MethodInfo method = typeof(NavigationExtensions).GetMethod("GetCurrentPage");
            MethodInfo genericMethod = method.MakeGenericMethod(t);
            return genericMethod.Invoke(null, null);

        }

        public static T GoTo<T>(this INavigationService document, string appendToUrl) where T : Page, new()
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

        public static bool IsAtPage<T>(this INavigationService document) where T : Page, new()
        {
            return document.IsAtPage(typeof(T));
        }

        public static bool IsAtPage(this INavigationService document, Type pageType)
        {
            var navigationInfo = TryGetPageDescriptionAttribute(pageType);

            if (navigationInfo == null)
                throw new InvalidOperationException("The page type does not specify its uri");

            return String.Equals(navigationInfo.Url.ToString(), document.Document.Uri.AbsolutePath, StringComparison.InvariantCultureIgnoreCase);
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