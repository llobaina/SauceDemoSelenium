using OpenQA.Selenium;
using SauceDemo.Config;

namespace SauceDemo.Pages;

public class BasePage(IWebDriver driver)
{
    private IWebElement Car => driver.WaitForElementToBeVisible(By.CssSelector("[data-test='shopping-cart-link']"));
    private IWebElement Badge => driver.WaitForElementToBeVisible(By.CssSelector("[data-test='shopping-cart-badge']"));
    public void ClickCar() 
    {
        Car.ClickElement();
    }

    public bool BadgeExist() //Para saber si existe este elemento en el carro
    {
        return driver.ElementExist(By.CssSelector("[data-test='shopping-cart-badge']"));
    }
    public int AmountItemsCar() ////Para saber cantidad de este elemento en el carro
    {
        return int.Parse(Badge.Text);
    }
}
