using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace SauceDemo.Enums;
//Esta clase define los tipos de navegadores
public enum BrowserType
{
    [Description("C")]
    Chrome,

    [Description("F")]
    Firefox,

    [Description("E")]
    Edge,

    [Description("S")]
    Safari
}
