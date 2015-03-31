using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using Selenium.Webdriver.Domify.Core;
using Selenium.Webdriver.Domify.Elements;
using Selenium.Webdriver.Domify.Javascript;

namespace Selenium.Webdriver.Domify
{
    
    public class Document : ListWebElements, IDocument
    {
        private readonly IWebDriver _driver;

        
        internal Document(IWebDriver driver, IDocumentSettings settings = null)
        {
            _driver = driver;

            Settings = settings ?? new DocumentSettings();
        }

        public Uri Uri
        {
            get
            {
                return new Uri(_driver.Url);
            }
        }

        public IDocumentHeader Header
        {
            get { return DocumentHeader.Create(_driver, this); }
        }

        public IDocumentSettings Settings
        {
            get { return GlobalConfiguration.Configuration; }
            set { GlobalConfiguration.Configuration = value; }
        }


        public string PageSource
        {
            get { return _driver.PageSource; }

        }

        private NavigationService _navigationService;
        public INavigationService Navigation
        {
            get
            {
                if(_navigationService == null) _navigationService = new NavigationService(this);
                return _navigationService;
            }
        }

        public bool IsPageLoaded
        {
            get
            {
                return Driver.ExecuteJavascript<string>(new GetDocumentReadyState()).Equals("complete", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        public IWebDriver Driver
        {
            get
            {

                return _driver;
            }
        }



        public T WaitUntilFound<T>(string id, ISearchContext inContext, TimeSpan timeout = default(TimeSpan))
            where T : WebElement, new()
        {
            return Driver.WaitUntilFound<T>(id, inContext, timeout);
        }

        public T WaitUntilFound<T>(By find, ISearchContext inContext, TimeSpan timeout = default(TimeSpan))
            where T : WebElement, new()
        {
            return Driver.WaitUntilFound<T>(find, inContext, timeout);
        }


        public T WaitUntilFound<T>(string id, TimeSpan timeout = default(TimeSpan))
            where T : WebElement, new()
        {
            return Driver.WaitUntilFound<T>(id, timeout);
        }

        public T WaitUntilFound<T>(By find, TimeSpan timeout = default(TimeSpan))
            where T : WebElement, new()
        {
            return Driver.WaitUntilFound<T>(find, timeout);
        }

        public void GoTo(string url)
        {
            Navigation.GoTo(url);
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public override IWebElement FindElement(By @by)
        {
            if (!Settings.AlwaysWaitForElement)
                return _driver.FindElement(@by);
            else
            {
                return TimeoutManager.Execute(Settings.WaitTimeout, () => _driver.FindElement(@by));
            }
        }

        public override ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _driver.FindElements(@by);
        }
    }


    public class DocumentHeader : IDocumentHeader
    {
        private readonly IWebDriver _driver;
        private readonly Document _document;
        private IDictionary<string, Meta> _meta;
        private IList<Style> _styles;
        private IList<Link> _links;
        private IList<Script> _scripts;
 
        private DocumentHeader(IWebDriver driver, Document document)
        {
            _driver = driver;
            _document = document;
        }

        public static IDocumentHeader Create(IWebDriver driver, Document document)
        {
            return new DocumentHeader(driver, document);
        }

        private Head Head
        {
            get
            {
                return _document.Find<Head>().FirstOrDefault();
            }
        }
        public string Title
        {
            get { return _driver.Title; }
        }

        public Base Base
        {
            get { return Head.Find<Base>().FirstOrDefault(); }
        }
        public IList<Style> Styles
        {
            get
            {
                if (_styles == null)
                {
                    _styles = new List<Style>();
                    foreach (var item in Head.Find<Style>())
                    {
                        _styles.Add(item);
                    }
                }

                return _styles;
            }
        }

        public IList<Link> Links
        {
            get
            {
                if (_links == null)
                {
                    _links = new List<Link>();
                    foreach (var item in Head.Find<Link>())
                    {
                        _links.Add(item);
                    }
                }

                return _links;
            }
        }

        public IList<Script> Scripts
        {
            get
            {
                if (_scripts == null)
                {
                    _scripts = new List<Script>();
                    foreach (var item in Head.Find<Script>())
                    {
                        _scripts.Add(item);
                    }
                }

                return _scripts;
            }
        }

        public IDictionary<string, Meta> Meta
        {
            get
            {
                if (_meta == null)
                {
                    _meta = new Dictionary<string, Meta>();
                    foreach (var meta in Head.Find<Meta>())
                    {
                        _meta.Add(meta.Name, meta);
                    }
                }

                return _meta;
            }
        }
    }
}