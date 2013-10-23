using System;
using Selenium.Webdriver.Domify.Exceptions;

namespace Selenium.Webdriver.Domify
{
    public class PageDescriptionAttribute : Attribute
    {
        private readonly string _url;

        public PageDescriptionAttribute(string title, string url)
        {
            _url = url;

            Title = title;
        }

        public Uri Url
        {
            get
            {
                var uri = new Uri(_url, UriKind.RelativeOrAbsolute);
                if (!uri.IsAbsoluteUri)
                {
                    if (GlobalConfiguration.Configuration.BaseUri == null)
                        throw new InvalidPageDescriptionException(InvalidPageDescriptionException.BaseUriRequired);

                    uri = new Uri(GlobalConfiguration.Configuration.BaseUri, _url);
                }
                return uri;
            }
        }

        public string Title { get; set; }
    }
}