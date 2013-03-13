namespace Selenium.Webdriver.Domify
{
    public class Page
    {
        private Document _driver;

        public Page()
        {

        }
        public Page(Document driver)
        {
            _driver = driver;
        }

        public Document Document { get { return _driver; } set { _driver = value; } }
    }
}