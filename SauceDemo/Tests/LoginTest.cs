using NUnit.Framework;

using SauceDemo.Config;
using SauceDemo.Pages;

namespace SauceDemo.Tests;

[TestFixture]
[TestFixtureSource(typeof(ConfigLoader), nameof(ConfigLoader.GetBrowsers))]
public class LoginTests(string browser) : BaseTest(browser)
{
    [Test]
    [Category("Login")]
    public void TestLogin()
    {
        LoginPage loginPage = new(Driver);
        loginPage.Login(Config.Username, Config.Password);
        Assert.That(loginPage.IsUserLoggedIn(Config.UrlAfterLogin), Is.True);
    }

    [Test]
    [Category("Login")]
    public void TestLoginUserNamelocked()
    {
        LoginPage loginPage = new(Driver);
        loginPage.Login(Config.UsernameLocked, Config.Password);
        Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }

    [Test]
    [Category("Login")]
    public void TestVerifyRequiredUser()
    {
        LoginPage loginPage = new(Driver);
        loginPage.ClickLogin();
        Assert.That(loginPage.GetErrorMessage(), Does.Contain("Username is required"));
    }

}
