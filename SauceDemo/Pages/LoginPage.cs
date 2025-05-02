using OpenQA.Selenium;
using SauceDemo.Config;

namespace SauceDemo.Pages
{
    //Ubicar los selectores a utilizar en la clase LoginPage
    public class LoginPage(IWebDriver driver)
    {
        private IWebElement UsernameField => driver.WaitForElementToBeVisible(By.Id("user-name"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement SubmitButton => driver.FindElement(By.Id("login-button"));

        private IWebElement ErrorMessage =>
            driver.WaitForElementToBeVisible(By.CssSelector("h3[data-test='error']"));
        //Acciones a realizar en la pagina
        public void Login(string username, string password)
        {
            UsernameField.EnterText(username);
            PasswordField.EnterText(password);
            SubmitButton.ClickElement();
        }

        public bool IsUserLoggedIn(string url)
        {
            return driver.Url.Equals(url);
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public void SetUserName(string username) 
        {
            UsernameField.EnterText(username);
        }
        public void SetPassword(string password)
        {
            PasswordField.EnterText(password);
        }
        public void ClickLogin ()
        {
            SubmitButton.ClickElement();
        }

    }
}
