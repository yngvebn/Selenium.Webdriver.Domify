using System.Web.Mvc;

namespace Selenium.Webdriver.Domify.Web.Controllers
{
    public class IsAtPageController : Controller
    {
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public ActionResult ParametersInQuery(int queryValue)
        {
            return View(queryValue);
        }
    }
}