using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Webdriver.Domify.GUITests.Core
{
    [TestFixture]
    public abstract class BrowserScenario
    {

        private readonly bool _setupBeforeEachScenario;


        protected BrowserScenario()
            : this(true)
        {

        }

        protected BrowserScenario(bool setupBeforeEachScenario)
        {
            _setupBeforeEachScenario = setupBeforeEachScenario;
        }

        private IDocument _document;

        public IDocument Document
        {
            get { return _document ?? (_document = BrowserTestSettings.Driver.Document()); }
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

        }


        protected abstract void Given();

        protected abstract void When();


    }
}