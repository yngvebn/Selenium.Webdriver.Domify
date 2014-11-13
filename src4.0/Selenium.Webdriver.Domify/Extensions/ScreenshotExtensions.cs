using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Javascript;

namespace Selenium.Webdriver.Domify
{
    public static class ScreenshotExtensions
    {
        public static byte[] GetScreenshot(this IWebDriver driver)
        {
            driver.ExecuteJavascript(new ExecuteHtml2Canvas());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string base64 = "";
            while (string.IsNullOrEmpty(base64))
            {
                base64 = driver.ExecuteJavascript<string>(new TryGetScreenshotBase64());
                if (sw.ElapsedMilliseconds > 30000) break;
                System.Threading.Thread.Sleep(500);
            }

            if (string.IsNullOrEmpty(base64)) return null;

            return Convert.FromBase64String(base64.Replace("data:image/png;base64,", ""));
        }

    }
}