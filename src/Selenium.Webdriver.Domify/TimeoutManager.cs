using System;
using System.Diagnostics;

namespace Selenium.Webdriver.Domify
{
    internal class TimeoutManager
    {
        public static T Execute<T>(TimeSpan waitTimeout, Func<T> func)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > waitTimeout.TotalMilliseconds) throw new TimeoutException("Timed out");
                try
                {
                    var element = func();
                    if (element == null) continue;
                    return element;
                }
                catch
                {
                    
                }
            }
        }

        public static void Execute<T>(TimeSpan waitTimeout, Predicate<T> func, T argument )
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > waitTimeout.TotalMilliseconds) throw new TimeoutException("Timed out");
                try
                {
                    if (func(argument)) break;
                }
                catch
                {

                }
            }
        }

    }
}