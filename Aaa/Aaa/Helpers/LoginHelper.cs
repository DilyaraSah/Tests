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

    public AccountData userData = new AccountData(Settings.Email, Settings.Password);
    public AccountData user2 = new AccountData("sahibdila@gmail.com", "12345kikiki");
    
    public void Login(AccountData user)
    {
        if (IsLoggedIn())
        {
            return;
        }
        driver.FindElement(By.Id("txtLogin")).Click();
        driver.FindElement(By.Id("txtLogin")).Clear();
        driver.FindElement(By.Id("txtLogin")).SendKeys("sahibdila@mail.ru");
        driver.FindElement(By.Id("txtPassword")).Click();
        driver.FindElement(By.Id("txtPassword")).Clear();
        driver.FindElement(By.Id("txtPassword")).SendKeys("kikiki237");
        driver.FindElement(By.LinkText("Вход")).Click();
    }

    public void Logout()
    {
        driver.FindElement(By.CssSelector("#mLogoff"));
    }
    
    public bool IsLoggedIn()
    {
        try
        {
            driver.FindElement(By.CssSelector("#mLogoff"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        return true;
    }
}