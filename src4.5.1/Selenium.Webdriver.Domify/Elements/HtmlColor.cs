using System.Drawing;

namespace Selenium.Webdriver.Domify.Elements
{

    
        // Summary:
        //     This class helps converting all kinds of html color formats to one uniform
        //     WatiN.Core.HtmlColor object. IE and FireFox return differently formatted
        //     results when retrieving a color, for instance backgroundColor. This class
        //     provides a way to keep your tests browser agnostic when it comes to checking
        //     color values.
        public class HtmlColor
        {
            
            // Summary:
            //     Initializes a new instance of the WatiN.Core.HtmlColor class.
            //
            // Parameters:
            //   value:
            //     The value.
            //
            // Exceptions:
            //   System.FormatException:
            //     Will be thrown if the value can't be converted to a color.
            public HtmlColor(string value)
            {
                OriginalValue = value;
                Color = ColorTranslator.FromHtml(value);
            }

            public static HtmlColor Aqua { get;private set; }
            public static HtmlColor Black { get;private set; }
            public static HtmlColor Blue { get;private set; }
            //
            // Summary:
            //     Returns the System.Drawing.Color wrapped by this class.
            public System.Drawing.Color Color { get; private set; }
            public static HtmlColor Fuchsia { get;private set; }
            public static HtmlColor Gray { get;private set; }
            public static HtmlColor Green { get; private set;}
            public static HtmlColor Lime { get; private set;}
            public static HtmlColor Maroon { get;private set; }
            public static HtmlColor Navy { get; private set;}
            public static HtmlColor Olive { get; private set;}
            public string OriginalValue { get; private set;}
            public static HtmlColor Purple { get; private set;}
            public static HtmlColor Red { get; private set;}
            public static HtmlColor Silver { get; private set;}
            public static HtmlColor Teal { get; private set;}
            //
            // Summary:
            //     Returns the color in a html hex code formatted string
            public string ToHexString { get { return ColorTranslator.ToHtml(Color); } }
            
            public string ToName { get { return Color.Name; }}

            public static HtmlColor White { get; private set; }
            public static HtmlColor Yellow { get; private set; }

            public bool Equals(HtmlColor that)
            {
                return that.Color.Equals(this.Color);
            }
            
            public override bool Equals(object obj)
            {
                return ((HtmlColor) obj).Equals(this);
            }
            public bool Equals(string color)
            {
                return ColorTranslator.FromHtml(color).Equals(Color);
            }
            //
            // Summary:
            //     Serves as a hash function for a particular type.
            //
            // Returns:
            //     A hash code for the current WatiN.Core.HtmlColor.
            public override int GetHashCode()
            {
                return Color.GetHashCode();
            }
            //
            // Summary:
            //     Returns a System.String that represents the current WatiN.Core.HtmlColor.
            //
            // Returns:
            //     A System.String that represents the current WatiN.Core.HtmlColor.
            public override string ToString()
            {
                return ToHexString;
            }
        
    }
}