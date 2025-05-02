using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemo.Config;

namespace SauceDemo.Pages
{
    public class ProductListPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly IWebDriver _driver = driver;
        private IWebElement SelectFilter => _driver.WaitForElementToBeVisible(By.CssSelector("[data-test='product-sort-container']"));

        private IWebElement ProductList => _driver.WaitForElementToBeVisible(By.CssSelector("[data-test='inventory-list']"));
        private IWebElement ButtonAddToCarBackPack => _driver.WaitForElementToBeClickable(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement ButtonRemoveToCarBackPack => _driver.WaitForElementToBeClickable(By.Id("remove-sauce-labs-backpack"));

        public void AddToCarBackPack()
        {
            ButtonAddToCarBackPack.ClickElement();
        }
        public void RemoveToCarBackPack() 
        {
            ButtonRemoveToCarBackPack.ClickElement();
        }
    }
        
}