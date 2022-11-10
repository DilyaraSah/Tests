using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Aaa;

public class LoginHelper:HelperBase
{
    public LoginHelper(ApplicationManager manager)
        : base(manager)
    {
    }

    public void Login(AccountData user)
    {
        driver.FindElement(By.Id("txtLogin")).Click();
        driver.FindElement(By.Id("txtLogin")).Clear();
        driver.FindElement(By.Id("txtLogin")).SendKeys("sahibdila@mail.ru");
        driver.FindElement(By.Id("txtPassword")).Click();
        driver.FindElement(By.Id("txtPassword")).Clear();
        driver.FindElement(By.Id("txtPassword")).SendKeys("kikiki237");
        driver.FindElement(By.LinkText("Вход")).Click();
    }
}