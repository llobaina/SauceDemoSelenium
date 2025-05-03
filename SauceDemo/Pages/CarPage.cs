using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemo.Config;

namespace SauceDemo.Pages
{
    public class CarPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly IWebDriver _driver = driver;

        private IWebElement CheckOut => _driver.WaitForElementToBeClickable(By.Id("checkout"));
    
        public void ClickCheckOut() {
                CheckOut.ClickElement();
            }

        }
}


