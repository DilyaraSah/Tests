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

public class ApplicationManager
{
    private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
    public IWebDriver driver;
    public StringBuilder verificationErrors;
    public string baseURL;

    private NavigationHelper navigation;
    private LoginHelper auth;
    private NoteHelper select;
    
    ~ApplicationManager()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        { 
            //ignore
        }
    }

    private ApplicationManager()
    {
        driver = new ChromeDriver();
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
        auth = new LoginHelper(this);
        navigation = new NavigationHelper(this, baseURL);
        select = new NoteHelper(this);
    }
    
    public static ApplicationManager GetInstance()
    {
        if (!app.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            newInstance.Navigation.OpenHomePage();
            app.Value = newInstance;
        }
        return app.Value;
    }


    public IWebDriver Driver
    {
        get { return driver; }
    }

    public NavigationHelper Navigation
    {
        get { return navigation; }
    }

    public LoginHelper Auth
    {
        get { return auth; }
    }
    
    
    public NoteHelper Select
    {
        get { return select; }
    }
    public void Stop()
    {
        driver.Quit();
    }
    
}
