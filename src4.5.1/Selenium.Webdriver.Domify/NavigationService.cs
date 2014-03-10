namespace Selenium.Webdriver.Domify
{
    public class NavigationService : INavigationService
    {
        public IDocument Document { get; private set; }

        internal NavigationService(IDocument document)
        {
            Document = document;
        }
    }
}