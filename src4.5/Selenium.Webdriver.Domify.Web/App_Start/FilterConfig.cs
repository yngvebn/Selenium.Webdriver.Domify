using System.Web;
using System.Web.Mvc;

namespace Selenium.Webdriver.Domify.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}