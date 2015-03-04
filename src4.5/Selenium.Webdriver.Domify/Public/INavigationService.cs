namespace Selenium.Webdriver.Domify
{
    public interface INavigationService
    {
        /// <summary>
        /// The Document this NavigationService is valid for
        /// </summary>
        IDocument Document { get; }
    }
}