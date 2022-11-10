using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Aaa
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        AccountData user = new AccountData("admin", "secret");

        [Test]
        public void TheUntitledTestCaseTest()
        {
            app.Navigation.OpenHomePage();
            Assert.That(app.driver.Url, Is.EqualTo("https://www.bumajko.ru/#!/note/0/0/0/"));
            app.Auth.Login(user);
            /*Thread.Sleep(1000);
            app.Adding.AddNote();
            Thread.Sleep(1000);
            app.Select.SelectLastCSelectLastCreatedNote();
            Thread.Sleep(1000);
            app.Delete.DeleteNote();
            Thread.Sleep(1000);*/
            app.Adding.ChangeContent();
            app.Stop();
            
            
        }

    }
}
