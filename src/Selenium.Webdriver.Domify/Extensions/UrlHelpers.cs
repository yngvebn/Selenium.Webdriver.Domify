using System;
using System.Text.RegularExpressions;

namespace Selenium.Webdriver.Domify
{
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

        public static bool MatchUrlPattern(string urlTemplate, Uri actual)
        {
            bool isAbsoluteUrlTemplate = IsAbsoluteUrl(urlTemplate);
            urlTemplate = Regex.Replace(urlTemplate, @"\?.*$", "");
            string pattern = Regex.Replace(urlTemplate, @"{(.*?)}", "(.*?)")+"(/?)$";

            return Regex.IsMatch(isAbsoluteUrlTemplate ? actual.GetLeftPart(UriPartial.Path) : actual.AbsolutePath, pattern, RegexOptions.IgnoreCase);
        }

        private static bool IsAbsoluteUrl(string urlTemplate)
        {
            Uri uri;
            return Uri.TryCreate(urlTemplate, UriKind.Absolute, out uri);
        }
    }
}