using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.Config
{
    //En esta clase se definen los metodos de Selenium 
    public static class CustomMethods
    {
        //Espera a que un elemento este visible
        public static IWebElement WaitForElementToBeVisible(
            this IWebDriver driver,
            By locator,
            int seconds = 10
        )
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        //Espera a que el elemento no este visible
        public static bool WaitForElementToBeNotVisible(
            this IWebDriver driver,
            By locator,
            int seconds = 10
        )
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        //Espera que un elemento se muestre y se oculte
        public static bool WaitForElementShowAndHide(
            this IWebDriver driver,
            By locator,
            int seconds = 10
        )
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        //Espera que un elemnto sea cliqueable
        public static IWebElement WaitForElementToBeClickable(
            this IWebDriver driver,
            By locator,
            int seconds = 10
        )
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(1000),
            };
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        //Espera que un elemento exista
        public static IWebElement WaitForElementExists(
            this IWebDriver driver,
            By locator,
            int seconds = 10
        )
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }
        //Para saber si el elemento existe
        public static bool ElementExist(this IWebDriver driver, By locator, int seconds = 10)
        {
            try
            {
                driver.WaitForElementExists(locator, seconds);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        //Para saber si el elemento es visisble
        public static bool ElementIsVisible(this IWebDriver driver, By locator, int seconds = 10)
        {
            try
            {
                driver.WaitForElementToBeVisible(locator, seconds);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        //Cliquear un elemento
        public static void ClickElement(this IWebElement locator) => locator.Click();
        //Limpia e Introduce un texto
        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
        //Selecciona por el texto en el selctor
        public static void SelectDropDownByText(this IWebElement locator, string text)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }
        //Selecciona por el valor en el selctor
        public static void SelectDropDownByValue(this IWebElement locator, string value)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }
        //Para seleccionar mas de un valor en el selector
        public static void MultiSelectElements(this IWebElement locator, string[] values)
        {
            var multiSelect = new SelectElement(locator);
            foreach (string value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }
        //Marcar un checkbox
        public static void CheckElement(this IWebElement locator)
        {
            if (!locator.Selected)
            {
                // If not selected, click the checkbox to select it
                locator.Click();
            }
        }
        //Desmarcar un checkbox
        public static void UnCheckElement(this IWebElement locator)
        {
            if (locator.Selected)
            {
               
                locator.Click();
            }
        }
        //Para hacer scroll hasta encontrar el elemento
        public static void ScrollToElements(this IWebDriver driver, IWebElement locator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(locator).Perform();
        }
        //Encontrar una alerta
        public static IAlert WaitForAlert(this IWebDriver driver, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
