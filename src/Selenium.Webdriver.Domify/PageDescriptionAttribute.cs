using System;
using Selenium.Webdriver.Domify.Exceptions;

namespace Selenium.Webdriver.Domify
{
    public class PageDescriptionAttribute : Attribute
    {

        public PageDescriptionAttribute(string title, string url)
        {
            PageUrl = url;

            Title = title;
        }

        public Uri Url
        {
            get
            {
                var uri = new Uri(PageUrl, UriKind.RelativeOrAbsolute);
                if (!uri.IsAbsoluteUri)
                {
                    if (GlobalConfiguration.Configuration.BaseUri == null)
                        throw new InvalidPageDescriptionException(InvalidPageDescriptionException.BaseUriRequired);

                    uri = new Uri(GlobalConfiguration.Configuration.BaseUri, PageUrl);
                }
                return uri;
            }
        }

        public string PageUrl { get; set; }
        public string Title { get; set; }
    }
}