using System;

namespace Selenium.Webdriver.Domify.Events
{
    public delegate void AfterNavigationEventHandler(object sender, NavigationEventArgs args);

    public delegate void BeforeNavigationEventHandler(object sender, NavigationEventArgs args);
    
    public class NavigationEventArgs
    {
        public string Uri { get; set; }
        public bool Cancel { get; set; }
    }
}