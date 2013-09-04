using System.IO;
using NUnit.Framework;
using Selenium.Webdriver.Domify.GUITests.Core;
using Selenium.Webdriver.Domify.GUITests.Pages;

namespace Selenium.Webdriver.Domify.GUITests
{
    [TestFixture]
    public class UploadFile : BrowserScenario
    {
        private string file = "";
        protected override void Given()
        {
            var dir = Directory.GetCurrentDirectory();
            file = Path.Combine(dir, "resources\\file.txt");
            Document.Navigation.GoTo<HomeIndex>();
        }

        protected override void When()
        {
            Document.Navigation.GetCurrentPage<HomeIndex>().FileUpload.File = (file);
        }

        [Then]
        public void TheFileShouldBeSetCorrectly()
        {
            Assert.That(Path.GetFileName(Document.Navigation.GetCurrentPage<HomeIndex>().FileUpload.File.ToLower()), Is.EqualTo(Path.GetFileName(file.ToLower())));
        }
    }
}