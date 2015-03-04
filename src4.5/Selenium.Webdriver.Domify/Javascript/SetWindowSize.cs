using System.Drawing;

namespace Selenium.Webdriver.Domify.Javascript
{
    public class SetWindowSize : Javascript
    {
        public SetWindowSize(Size size)
            : base(string.Format("window.resizeTo({0}, {1});", size.Width, size.Height))
        {

        }
    }
}