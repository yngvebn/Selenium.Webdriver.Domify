using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Selenium.Webdriver.Domify.Cache;

namespace Selenium.Webdriver.Domify
{
    public static class NavigationExtensions
    {
        private static T Page<T>(this INavigationService webDriver) where T : Page, new()
        {
            var t = new T {Document = webDriver.Document};
            return t;
        }


        /// <summary>
        ///     Shortcut to Current.Page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCurrentPage<T>(this INavigationService document) where T : Page, new()
        {
            return document.Page<T>();
        }

        public static T GoTo<T>(this INavigationService document, object arguments) where T: Page, new()
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute<T>();

        

            if (navigationInfo != null)
            {
                    var url = ProcessUrlArguments(navigationInfo.Url, arguments);
                    document.GoToPageUrl(url);
            }
            else
                throw new InvalidOperationException(
                    "You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static Uri ProcessUrlArguments(Uri uri, object routeValues)
        {
            if (routeValues == null) return uri;
            string url = uri.ToString();
            string regexPattern = "{{{0}.*?}}";
            foreach (var property in routeValues.GetType().GetProperties())
            {
                url = Regex.Replace(url, string.Format(regexPattern, property.Name), property.GetValue(routeValues, null).ToString(), RegexOptions.IgnoreCase);
            }
            url = Regex.Replace(url, string.Format(regexPattern, ""), "");
            return new Uri(url);
        }

        /// <summary>
        ///     Browses to the given Page with the current browser window
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GoTo<T>(this INavigationService document) where T : Page, new()
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute<T>();

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException(
                    "You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static void GoToPageUrl(this INavigationService document, Uri relativeUrl)
        {
            document.Document.Driver.Navigate().GoToUrl(relativeUrl);
        }


        /// <summary>
        ///     Browses to the given URI with the current browser window
        /// </summary>
        public static void GoTo(this INavigationService document, Uri uri)
        {
            document.GoToPageUrl(uri);
        }

        public static void GoTo(this INavigationService document, Assembly containingAssembly, string pageTitle)
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute(containingAssembly, pageTitle);

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException(
                    "Unable to find page with title "+pageTitle);
        }

        /// <summary>
        ///     Browses to the given Page with the current browser window
        /// </summary>
        public static object GoTo(this INavigationService document, Type t)
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute(t);

            if (navigationInfo != null)
                document.GoToPageUrl(navigationInfo.Url);
            else
                throw new InvalidOperationException(
                    "You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");
            MethodInfo method =  typeof (NavigationExtensions).GetMethod("GetCurrentPage");
            MethodInfo genericMethod = method.MakeGenericMethod(t);
            return genericMethod.Invoke(null, null);
        }

        /// <summary>
        ///     Navigates to the given page with the additional URL-string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="appendToUrl">Extra string to append to the Page-URL</param>
        /// <returns></returns>
        public static T GoTo<T>(this INavigationService document, string appendToUrl) where T : Page, new()
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute<T>();

            if (navigationInfo != null)
                document.GoToPageUrl(Build(navigationInfo.Url, appendToUrl));
            else
                throw new InvalidOperationException(
                    "You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static Uri Build(Uri url, string appendToUrl)
        {
            var uri = new Uri(url + appendToUrl);
            return uri;
        }

        /// <summary>
        ///     Checks if the current browser is at the given page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <returns></returns>
        public static bool IsAtPage<T>(this INavigationService document) where T : Page, new()
        {
            return document.IsAtPage(typeof (T));
        }

        /// <summary>
        ///     Checks if the current browser is at the given page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <returns></returns>
        public static bool IsAtPage(this INavigationService document, Type pageType)
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute(pageType);

            if (navigationInfo == null)
                throw new InvalidOperationException("The page type does not specify its uri");

            return
                String.Equals(navigationInfo.Url.ToString(), document.Document.Uri.AbsolutePath,
                              StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(navigationInfo.Url.ToString(), document.Document.Uri.ToString(),
                              StringComparison.InvariantCultureIgnoreCase);
        }
        private static PageDescriptionAttribute TryGetPageDescriptionAttribute(Assembly containingAssembly, string pageTitle)
        {
            return CacheHolder.TryGetPageDescriptionAttribute(containingAssembly, pageTitle);
        }

        private static PageDescriptionAttribute TryGetPageDescriptionAttribute(Type t)
        {
            return CacheHolder.TryGetPageDescriptionAttribute(t);
        }

        private static PageDescriptionAttribute TryGetPageDescriptionAttribute<T>()
        {
            return CacheHolder.TryGetPageDescriptionAttribute(typeof (T));
        }
    }
}