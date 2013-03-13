namespace Selenium.Webdriver.Domify
{
    public class Page
    {
        public Page()
        {

        }
        public Page(IDocument driver)
        {
            Document = driver;
        }

        public IDocument Document { get; set; }
    }
}