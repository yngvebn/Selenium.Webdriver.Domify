using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify.GUITests.Pages
{
    [PageDescription("SelectLists", "http://localhost:31337/Home/SelectLists")]
    public class HomeSelectLists : Page
    {
        public SelectList MainList { get { return Document.SelectList("mainList"); }}

        public SelectList DelayedList { get { return Document.SelectList("delayedList"); } }

        public Table Table
        {
            get { return Document.Table("table"); }
        }

        public Table TableWithBodies
        {
            get { return Document.Table("tableWithMultipleBodies"); }
        }


        public Table TableWithPlainRows
        {
            get { return Document.Table("tableWithPlainRows"); }
        }
    }
}