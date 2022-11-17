using System.Threading;
using NUnit.Framework;

namespace Aaa.Tests;

[TestFixture]
public class Login : TestBase
{
    [Test]
    public void LoginWithValidData()
    {
        app.Navigation.OpenHomePage();
        app.Auth.Login(app.Auth.userData);
        Thread.Sleep(5000);
        app.Auth.Login(app.Auth.user2);
    }

    [Test]
    public void LoginWithInvalidData()
    {
        app.Auth.Login(new AccountData("wrong", "invalid"));
    }
}