using System.Collections.Generic;
using Selenium.Webdriver.Domify.Elements;

namespace Selenium.Webdriver.Domify
{
    public interface IListWebElements
    {
        IList<Span> Spans { get; }
        IList<Fieldset> Fieldsets { get; }
        IList<Frame> Frames { get; }
        IList<UL> Lists { get; }
        IList<Div> Divs { get; }
        IList<HyperLink> Links { get; }
        IList<Table> Tables { get; }
        IList<CheckBox> CheckBoxes { get; }
        IList<SelectList> SelectLists { get; }
        IList<DateField> DateFields { get; }
        IList<TextArea> TextAreas { get; }
        IList<TextField> TextFields { get; }
        IList<Button> Buttons { get; }
        IList<FileUpload> FileUploads { get; }
        IList<Form> Forms { get; }
        IList<H1> H1s { get; }
        IList<H2> H2s{ get; }
        IList<H3> H3s{ get; }
        IList<P> Ps { get; }
        IList<HtmlElement> Elements { get; }
        IList<RadioButton> RadioButtons { get; }
        IList<Hidden> Hiddens { get;  }
        IList<Range> RangeInputs { get;  }
        IList<ColorInput> ColorInputs { get;  } 

    }
}