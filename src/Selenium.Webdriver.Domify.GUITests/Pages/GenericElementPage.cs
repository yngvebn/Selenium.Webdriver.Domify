namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    //[PageDescription("Element", "http://localhost:31338/element/element?type={type}&tag={tag}&id={id}&childTags={childTags}&text={text}")]
    [PageDescription("Element", "http://localhost:31338/element/element")]
    public class GenericElementPage: Page
    {
    }

    
    [PageDescription("PageWithQuery", "http://localhost:31338/tests/query?t={token}&u={username}")]
    public class PageWithQueryString : Page
    {
        
    }

    [PageDescription("PageWithHashBang", "http://localhost:31338/#/{token}/{username}")]
    public class PageWithHashBang: Page
    {
        
    }

    [PageDescription("PageWithQuery", "http://localhost:31338/tests")]
    public class RootPageWithoutQuery : Page
    {

    }
}