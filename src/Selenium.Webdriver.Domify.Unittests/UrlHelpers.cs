using System;
using NUnit.Framework;

namespace Selenium.Webdriver.Domify.Unittests
{
    [TestFixture]
    public class UrlHelperTests
    {
        [TestCase("http://can.be.anything/something", "http://can.be.anything/something", true)]
        [TestCase("http://can.be.anything/something", "http://can.be.anything/somethingElse", false)]
        [TestCase("http://can.be.anything/somethingElse", "http://can.be.anything/something", false)]
        [TestCase("http://can.be.anything/something/", "http://can.be.anything/something", true)]
        [TestCase("http://can.be.anything/something/", "http://can.be.anything/something/", true)]
        [TestCase("http://can.be.anything/something", "http://can.be.anything/something/", true)]
        [TestCase("http://can.be.anything/something?query=value", "http://can.be.anything/something/", true)]
        [TestCase("http://can.be.anything/something", "http://can.be.anything/something?query=value", true)]
        [TestCase("http://can.be.anything/something?query=value", "http://can.be.anything/something?query=value", true)]
        [TestCase("/something?query=value", "http://can.be.anything/something", true)]
        public void ValidateUrls(string actual, string expected, bool shouldEqual)
        {
            Assert.That(UrlHelpers.UrlsAreEqual(new Uri(actual, UriKind.RelativeOrAbsolute), new Uri(expected, UriKind.RelativeOrAbsolute)), Is.EqualTo(shouldEqual));
        }
    }
}