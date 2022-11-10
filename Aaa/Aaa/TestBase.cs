using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Aaa;

public class TestBase
{
    protected ApplicationManager app;
    //ApplicationManager app = ApplicationManager.GetInstance();
    public IWebDriver driver;
    [SetUp]
    public void SetupTest()
    {
        app = ApplicationManager.GetInstance();
    }
    
    /*[TearDown]
    public void TeardownTest()
    {
        app.Stop();
    }*/
    
}