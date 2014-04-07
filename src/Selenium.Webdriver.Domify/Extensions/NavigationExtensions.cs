using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.Webdriver.Domify.Cache;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.Events;
using Selenium.Webdriver.Domify.Factories;

namespace Selenium.Webdriver.Domify
{
    public static class NavigationExtensions
    {

        private static T Page<T>(this INavigationService webDriver) where T : Page, new()
        {
            return PageProxyFactory.CreatePageProxy<T>(webDriver.Document);
        }

        /// <summary>
        ///     Shortcut to Current.Page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCurrentPage<T>(this INavigationService document) where T : Page, new()
        {
            return GetPage<T>(document);
        }

        public static T GetPage<T>(INavigationService document) where T : Page, new()
        {
            return document.Page<T>();
        }

        public static T GoTo<T>(this INavigationService document, dynamic arguments) where T : Page, new()
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute<T>();

            if (navigationInfo != null)
            {
                Uri url = ProcessUrlArguments(navigationInfo.Url, arguments);
                document.GoToPageUrl(url);
            }
            else
                throw new InvalidOperationException(
                    "You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");

            return document.GetCurrentPage<T>();
        }

        private static Uri ProcessUrlArguments(Uri uri, dynamic routeValues)
        {
            string url = uri.ToString();
            routeValues = routeValues ?? new { };
            Dictionary<string, string> properties = new Dictionary<string, string>();
            foreach (var property in routeValues.GetType().GetProperties())
            {
                properties.Add(property.Name, property.GetValue(routeValues, null).ToString());
            }
            List<string> propertyNames = new List<string>(properties.Select(c => c.Key));
            string regexPattern = "{{{0}.*?}}";
            foreach (var property in properties.Keys)
            {
                if (Regex.IsMatch(url, string.Format(regexPattern, property), RegexOptions.IgnoreCase))
                {
                    url = Regex.Replace(url, string.Format(regexPattern, property), properties[property], RegexOptions.IgnoreCase);
                    propertyNames.Remove(property);
                }
            }
            url = Regex.Replace(url, @"\{.*\}", "");
            string queryString = "";
            foreach (var propertyName in propertyNames)
            {
                queryString += string.Format("{0}={1}&", propertyName, properties[propertyName]);
            }
            queryString = queryString.TrimEnd('&');
            if (!string.IsNullOrEmpty(queryString)) queryString = "?" + queryString;

            return new Uri(url + queryString);
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
            var navigationService = document as NavigationService;
            if (navigationService != null)
            {
                NavigationEventArgs args = new NavigationEventArgs()
                {
                    Uri = relativeUrl.ToString(),
                    Cancel = false
                };
                navigationService.OnBeforeNavigation(args);
                if (args.Cancel) return;
                relativeUrl = new Uri(args.Uri);
            }

            document.Document.Driver.Navigate().GoToUrl(relativeUrl);
        }

        private static void GoToPageUrl(this INavigationService document, string relativeUrl)
        {
            var navigationService = document as NavigationService;
            if (navigationService != null)
            {
                var args = new NavigationEventArgs()
                {
                    Uri = relativeUrl,
                    Cancel = false
                };
                navigationService.OnBeforeNavigation(args);
                if (args.Cancel) return;
                relativeUrl = args.Uri;
            }
            document.Document.Driver.Navigate().GoToUrl(relativeUrl);
        }


        /// <summary>
        ///     Browses to the given URI with the current browser window
        /// </summary>
        public static void GoTo(this INavigationService document, Uri uri)
        {
            document.GoToPageUrl(ProcessUrlArguments(uri, new { }));
        }

        /// <summary>
        ///     Browses to the given URI with the current browser window
        /// </summary>
        public static void GoTo(this INavigationService document, string uri)
        {
            document.GoToPageUrl(ProcessUrlArguments(new Uri(uri, UriKind.RelativeOrAbsolute), new { }));
        }

        public static void GoTo(this INavigationService document, Assembly containingAssembly, string pageTitle)
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute(containingAssembly, pageTitle);

            if (navigationInfo != null)
                document.GoToPageUrl(ProcessUrlArguments(navigationInfo.Url, new { }));
            else
                throw new InvalidOperationException(
                    "Unable to find page with title " + pageTitle);
        }



        /// <summary>
        ///     Browses to the given Page with the current browser window
        /// </summary>
        public static object GoTo(this INavigationService document, Type t, dynamic arguments)
        {
            PageDescriptionAttribute navigationInfo = TryGetPageDescriptionAttribute(t);
            Uri url = ProcessUrlArguments(navigationInfo.Url, arguments);
            if (navigationInfo != null)
                document.GoToPageUrl(url);
            else
                throw new InvalidOperationException(
                    "You are trying to navigate to a page which does not specify its uri (missing PageDescriptionAttribute)");
            MethodInfo method = typeof(NavigationExtensions).GetMethod("GetPage");
            MethodInfo genericMethod = method.MakeGenericMethod(t);
            return genericMethod.Invoke(null, new object[] { document });
        }


        /// <summary>
        ///     Browses to the given Page with the current browser window
        /// </summary>
        public static object GoTo(this INavigationService document, Type t)
        {
            return document.GoTo(t, new { });
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
            return document.IsAtPage(typeof(T));
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


            return UrlHelpers.UrlsAreEqual(ProcessUrlArguments(navigationInfo.Url, null), document.Document.Uri);

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
            return CacheHolder.TryGetPageDescriptionAttribute(typeof(T));
        }
    }

    public static class UrlHelpers
    {
        public static bool UrlsAreEqual(Uri expected, Uri actual)
        {
            if (expected.ToString().Equals(actual.ToString(), StringComparison.InvariantCultureIgnoreCase)) return true;

            expected = expected.IsAbsoluteUri ? expected : new Uri(new Uri("http://can.be.anything/"), expected.ToString());
            actual = actual.IsAbsoluteUri ? actual : new Uri(new Uri("http://can.be.anything/"), actual.ToString());

            if (expected.AbsolutePath.TrimEnd('/').Equals(actual.AbsolutePath.TrimEnd('/'), StringComparison.InvariantCultureIgnoreCase)) return true;

            return false;
        }
    }
}