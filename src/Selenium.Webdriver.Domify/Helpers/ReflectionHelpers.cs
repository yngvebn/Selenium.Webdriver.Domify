using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Selenium.Webdriver.Domify
{
    public static class ReflectionHelpers
    {
        public static T GetCustomAttribute<T>(this Type o, bool inherit)
        {
            return o.GetCustomAttributes(typeof (T), inherit).Cast<T>().FirstOrDefault();
        }

        public static T GetCustomAttribute<T>(this Type o)
        {
            return o.GetCustomAttribute<T>(false);
        }

        public static T GetCustomAttribute<T>(this PropertyInfo o, bool inherit)
        {
            return o.GetCustomAttributes(typeof(T), inherit).Cast<T>().FirstOrDefault();
        }

        public static T GetCustomAttribute<T>(this PropertyInfo o)
        {
            return o.GetCustomAttribute<T>(false);
        }
    }
}