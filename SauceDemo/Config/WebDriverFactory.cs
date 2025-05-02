using SauceDemo.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace SauceDemo.Config;
//Esta clase Crea una instancia del WebDriver para el navegador seleccionado
public static class WebDriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browser, bool headless, bool mobile)
    {
        switch (browser)
        {
            case BrowserType.Chrome:
                var chromeOptions = new ChromeOptions();
                if (headless)
                {
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--disable-gpu");
                }
                if (mobile)
                {
                    chromeOptions.EnableMobileEmulation("iPhone X");
                }
                return new ChromeDriver(chromeOptions);
            case BrowserType.Firefox:
                var firefoxOptions = new FirefoxOptions();
                if (headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }
                return new FirefoxDriver(firefoxOptions);
            case BrowserType.Edge:
                var edgeOptions = new EdgeOptions();
                if (headless)
                {
                    edgeOptions.AddArgument("--headless");
                    edgeOptions.AddArgument("--disable-gpu");
                }
                if (mobile)
                {
                    edgeOptions.EnableMobileEmulation("iPhone X");
                }
                return new EdgeDriver(edgeOptions);
            case BrowserType.Safari:
                if (headless)
                {
                    throw new ArgumentException("Safari does not support headless mode.");
                }
                return new SafariDriver();
            default:
                throw new ArgumentException("Browser not supported");
        }
    }
}
