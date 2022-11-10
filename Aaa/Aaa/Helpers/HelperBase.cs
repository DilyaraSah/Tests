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

public class HelperBase
{
    protected IWebDriver driver;
    protected bool acceptNextAlert = true;
    protected ApplicationManager manager;

    public HelperBase(ApplicationManager manager)
    {
        this.manager = manager;
        this.driver = manager.Driver;
    }

    
    public string CloseAlertAndGetItsText() {
        try {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert) {
                alert.Accept();
            } else {
                alert.Dismiss();
            }
            return alertText;
        } finally {
            acceptNextAlert = true;
        }
    }
    
    public bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }
    
    public bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}