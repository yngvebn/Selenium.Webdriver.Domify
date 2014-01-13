namespace Selenium.Webdriver.Domify
{
    public abstract class Page
    {
        protected Page()
        {

        }

        public virtual IDocument Document { get; set; }
    }
}