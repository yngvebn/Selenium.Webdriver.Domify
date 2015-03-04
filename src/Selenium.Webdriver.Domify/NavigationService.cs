using Selenium.Webdriver.Domify.Events;

namespace Selenium.Webdriver.Domify
{
    public class NavigationService : INavigationService
    {
        public IDocument Document { get; private set; }
        public event BeforeNavigationEventHandler BeforeNavigation;
        public event AfterNavigationEventHandler AfterNavigation;

        internal void OnBeforeNavigation(NavigationEventArgs args)
        {
            if (BeforeNavigation != null)
            {
                BeforeNavigation(this, args);
            }
        }

        internal NavigationService(IDocument document)
        {
            Document = document;
        }

        public void OnAfterNavigation(NavigationEventArgs args)
        {
            if (AfterNavigation != null)
            {
                AfterNavigation(this, args);
            }
        }
    }
}