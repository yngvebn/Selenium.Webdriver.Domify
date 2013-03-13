using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Webdriver.Domify.GUITests.Core
{
    [TestFixture]
    public abstract class BrowserScenario
    {

        private readonly bool _setupBeforeEachScenario;
        private Document _document;
        
        protected BrowserScenario()
            : this(true)
        {
            
        }

        protected BrowserScenario(bool setupBeforeEachScenario)
        {
            _setupBeforeEachScenario = setupBeforeEachScenario;
        }

        public Document Document
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

        private void Initialize()
        {
            IWebDriver driver = new ChromeDriver();
            _document = new Document(driver);

        }

        [TestFixtureTearDown]
        public void KillBrowsers()
        {
            _document.Driver.Close();
            _document.Driver.Dispose();
        }

        protected abstract void Given();

        protected abstract void When();


    }
}