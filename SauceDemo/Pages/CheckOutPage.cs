
using OpenQA.Selenium;
using SauceDemo.Config;


namespace SauceDemo.Pages
{
    public class CheckOutPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly IWebDriver _driver = driver;

        private IWebElement ButtonContinue => _driver.WaitForElementToBeClickable(By.Id("continue"));
        private IWebElement ButtonCancel => _driver.WaitForElementToBeClickable(By.Id("cancel"));
        private IWebElement FirstName => _driver.WaitForElementToBeVisible(By.Id("first-name"));
        private IWebElement LastName => _driver.WaitForElementToBeVisible(By.Id("last-name"));
        private IWebElement PostalCode => _driver.WaitForElementToBeVisible(By.Id("postal-code"));


        public void ClickButtonContinue()
        {
            ButtonContinue.ClickElement();
        }
        public void ClickButtonCancel() 
        {
            ButtonCancel.ClickElement();
        }
        public void EnterFirstName(string firstname)
        {
            FirstName.EnterText(firstname);
        }
        public void EnterLastName(string lastname)
        {
            LastName.EnterText(lastname);
        }
        public void EnterPostalCode(string postalCode)
        {
            PostalCode.EnterText(postalCode);
        }

    }

}

