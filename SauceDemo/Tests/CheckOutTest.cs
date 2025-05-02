
using SauceDemo.Config;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    //Las 2 sigiuentes lineas se utilizan para obtener los navegadores definidos en el .env 
    [TestFixture]
    [TestFixtureSource(typeof(ConfigLoader), nameof(ConfigLoader.GetBrowsers))]

    public class CheckOutTest(string browser) : BaseTest(browser) //levantar el navegador
    {
        private void Login(string username, string password) //loguiar un usuario
        {
            LoginPage loginPage = new(Driver);
            loginPage.Login(username, password);
        }

        [Test]
        public void CheckOut()
        {
            Login(Config.Username, Config.Password);
            ProductListPage productlistpage = new(Driver);
            productlistpage.AddToCarBackPack();
            productlistpage.ClickCar();
            CarPage carPage = new(Driver);
            carPage.ClickCheckOut();
            CheckOutPage checkOutPage = new(Driver);
            checkOutPage.EnterFirstName("Laritza");
            checkOutPage.EnterLastName("Lopez Lobaina");
            checkOutPage.EnterPostalCode("10400");
            checkOutPage.ClickButtonContinue();
            CheckOutOverview checkOutOverview = new(Driver);
            checkOutOverview.ClickFinish();
        }


    }

}

