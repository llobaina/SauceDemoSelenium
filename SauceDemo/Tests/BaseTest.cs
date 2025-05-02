using SauceDemo.Config;
using SauceDemo.Enums;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using NUnit.Framework;


namespace SauceDemo.Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.All)] //para correr los test en paralelo
public abstract class BaseTest(string browser)
{
    protected IWebDriver Driver;
    protected static readonly AppConfig Config = ConfigLoader.LoadConfig();
    protected readonly BrowserType CurrentBrowser = EnumHelper.ConvertStringToEnum<BrowserType>(
        browser
    );
    //Antes de empezar el test levanta el navegador
    [SetUp]
    public void SetUp()
    {
        Driver = WebDriverFactory.CreateDriver(CurrentBrowser, Config.Headless, Config.Mobile);
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(Config.BaseUrl);
    }
    //Luego de terminar el test
    [TearDown]
    public void TearDown()
    {
        //Este metodo si falla el test lo guarda en un log y guarda una foto 
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
                return;
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string screenshotDirectory = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "Screenshots"
            );
            Directory.CreateDirectory(screenshotDirectory);
            string screenshotPath = Path.Combine(
                screenshotDirectory,
                $"{TestContext.CurrentContext.Test.Name}.png"
            );
            screenshot.SaveAsFile(screenshotPath);
            TestContext.AddTestAttachment(screenshotPath);
        }
        finally
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
    //Capturar cualquier error que pase en el test
    protected static void ExecuteWithExceptionHandling(Action testMethod)
    {
        try
        {
            testMethod();
        }
        catch (StaleElementReferenceException)
        {
            Assert.Fail("Test failed due to a StaleElementReferenceException.");
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail("Test failed due to a WebDriverTimeoutException.");
        }
    }
}
