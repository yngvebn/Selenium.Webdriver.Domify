namespace Selenium.Webdriver.Domify
{
    public abstract class Page
    {
        protected Page()
        {

        }

        protected Page(IDocument driver)
        {
            Document = driver;
        }

        public IDocument Document { get; set; }
    }
}