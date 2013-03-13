using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Webdriver.Domify.GUITests.Core
{
    [TestFixture]
    public abstract class BrowserScenario
    {

        private readonly bool _setupBeforeEachScenario;
        private IDocument _document;
        
        protected BrowserScenario()
            : this(true)
        {
            
        }

        protected BrowserScenario(bool setupBeforeEachScenario)
        {
            _setupBeforeEachScenario = setupBeforeEachScenario;
        }

        public IDocument Document
        {
            get { return _document; }
        }

        [TestFixtureSetUp]
        public void InitializeBeforeEachScenario()
        {
            if (_setupBeforeEachScenario)
            {
                Initialize();

                Given();
                When();
            }
        }

        [SetUp]
        public void InitializeBeforeEachTest()
        {
            if (!_setupBeforeEachScenario)
            {
                Initialize();

                Given();
                When();
            }
        }

        private IWebDriver _driver;
        private void Initialize()
        {
            _driver = new ChromeDriver();
            _document = new Document(_driver);

        }

        [TestFixtureTearDown]
        public void KillBrowsers()
        {
            _driver.Close();
            _driver.Dispose();
        }

        protected abstract void Given();

        protected abstract void When();


    }
}