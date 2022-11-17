using NUnit.Framework;

namespace Aaa;

public class AuthBase : TestBase
{
    protected ApplicationManager app;

    [SetUp]
    public void Setup()
    {
        app = ApplicationManager.GetInstance();
        app.Navigation.OpenHomePage();
        app.Auth.Login(app.Auth.userData);
    }
}