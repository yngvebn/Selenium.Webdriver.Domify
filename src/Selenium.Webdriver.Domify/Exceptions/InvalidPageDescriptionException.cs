using System;

namespace Selenium.Webdriver.Domify.Exceptions
{
    public class InvalidPageDescriptionException: Exception
    {
        public const string BaseUriRequired = "Document.Settings.BaseUri is required when using relative URIs on PageDescription";

        public InvalidPageDescriptionException(string message)
            :base(message)
        {
            
        }
    }
}