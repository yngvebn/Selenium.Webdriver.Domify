using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class SpanClickTest: PageScenario<SpanTestPage>
    {
        protected override void When()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach(var span in CurrentPage.Container.Spans)
            {
                span.Click();
            }
            Console.WriteLine(string.Format("{0} spans clicked in {1}ms", CurrentPage.Container.Spans.Count,  watch.ElapsedMilliseconds));
          
        }

        [Then]
        public void JustAssertTrue()
        {
            Assert.That(true, Is.True);
        }
    }
}