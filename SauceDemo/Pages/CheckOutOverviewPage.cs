
using OpenQA.Selenium;
using SauceDemo.Config;

namespace SauceDemo.Pages
{
    public class CheckOutOverviewPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly IWebDriver _driver = driver;

        private IWebElement Finish=> _driver.WaitForElementToBeClickable(By.Id("finish"));

        public void ClickFinish()
        {
            Finish.ClickElement();
        }

    }
}
