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
    private AddingHelper adding;
    private DeleteHelper delete;
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
        driver = new ChromeDriver("D:\\Program Files");
        baseURL = "https://www.google.com/";
        verificationErrors = new StringBuilder();
        adding = new AddingHelper(this);
        auth = new LoginHelper(this);
        navigation = new NavigationHelper(this, baseURL);
        delete = new DeleteHelper(this);
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

    public AddingHelper Adding
    {
        get { return adding; }
    }
    
    public DeleteHelper Delete
    {
        get { return delete; }
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
