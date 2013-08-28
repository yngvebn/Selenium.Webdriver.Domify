using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;

namespace Selenium.Webdriver.Domify
{
    internal class TimeoutManager
    {
        public static T Execute<T>(TimeSpan waitTimeout, Func<T> func, Type[] ignoredExceptionTypes = null) where T : class
        {
            Exception lastException = null;

            if (ignoredExceptionTypes == null)
                ignoredExceptionTypes = new Type[] { };

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > waitTimeout.TotalMilliseconds)
                {
                    if (lastException != null)
                    {
                        throw new TimeoutException(string.Format("Timeout, last known cause was: {0}", lastException.Message), lastException);
                    }
                    else
                        throw new TimeoutException("Timed out");
                }

                try
                {
                    var element = func();

                    if (element != null)
                        return element;
                }
                catch (Exception e)
                {
                    lastException = CommonExceptionHandling(ignoredExceptionTypes, e);
                }
            }
        }

        public static void Execute(TimeSpan waitTimeout, Func<bool> func, Type[] ignoredExceptionTypes = null)
        {
            Exception lastException = null;

            if (ignoredExceptionTypes == null)
                ignoredExceptionTypes = new Type[] { };

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > waitTimeout.TotalMilliseconds)
                {
                    if (lastException != null)
                    {
                        throw new TimeoutException(string.Format("Timeout, last known cause was: {0}", lastException.Message), lastException);
                    }
                    else
                        throw new TimeoutException("Timed out");
                }

                try
                {
                    if (func())
                        return;
                }
                catch (Exception e)
                {
                    lastException = CommonExceptionHandling(ignoredExceptionTypes, e);
                }
            }
        }

        public static void Execute<T>(TimeSpan waitTimeout, Predicate<T> func, T argument, Type[] ignoredExceptionTypes = null)
        {
            Exception lastException = null;

            if (ignoredExceptionTypes == null)
                ignoredExceptionTypes = new Type[]{};

            var watch = new Stopwatch();
            watch.Start();
            while (true)
            {
                if (watch.ElapsedMilliseconds > waitTimeout.TotalMilliseconds)
                {
                    if (lastException != null)
                    {
                        throw new TimeoutException(string.Format("Timeout, last known cause was: {0}", lastException.Message), lastException);
                    }
                    else
                        throw new TimeoutException("Timed out");
                }

                try
                {
                    if (func(argument)) break;
                }
                catch (Exception e)
                {
                    lastException = CommonExceptionHandling(ignoredExceptionTypes, e);
                }
            }
        }

        private static Exception CommonExceptionHandling(IEnumerable<Type> ignoredExceptionTypes, Exception e)
        {
            if (ignoredExceptionTypes.All(type => type != e.GetType()))
            {
                if (e is StaleElementReferenceException)
                    throw e;
            }

            return e;
        }
    }
}