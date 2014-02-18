using System;

namespace Selenium.Webdriver.Domify.Helpers
{
    public static class EnumHelpers
    {
        public static T CastTo<T>(this string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue, true);
        }
    }
}