
using SauceDemo.Config;
using SauceDemo.Pages;

namespace SauceDemo.Tests
{
    //Las 2 sigiuentes lineas se utilizan para obtener los navegadores definidos en el .env 
    [TestFixture]
    [TestFixtureSource(typeof(ConfigLoader), nameof(ConfigLoader.GetBrowsers))]
    
    public class ProductListTest(string browser) : BaseTest(browser) //levantar el navegador
    {
       private void Login(string username,string password) //loguiar un usuario
        {
            LoginPage loginPage = new(Driver);
            loginPage.Login(username, password);
        }
        
        [Test]
        public void AddToCart()
        {
            Login(Config.Username, Config.Password);
            ProductListPage productlistpage = new(Driver);
            int amountitemscar = 0;
            if (productlistpage.BadgeExist()) 
            {
                amountitemscar = productlistpage.AmountItemsCar();
            }
            productlistpage.AddToCarBackPack();
            Assert.That(amountitemscar + 1, Is.EqualTo(productlistpage.AmountItemsCar()));
        }
        

    }

}
