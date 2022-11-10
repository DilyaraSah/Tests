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

public class AddingHelper:HelperBase
{
    public AddingHelper(ApplicationManager manager)
        : base(manager)
    {
    }
    
    public void AddNote()
    {
        //driver.Navigate().GoToUrl("https://www.bumajko.ru/#!/note/0/0/0/");
        driver.FindElement(By.XPath("//div[@id='block-top']/div/div/a[7]")).Click();
        
    }

    public void ChangeContent()
    {
        string path = manager.Select.GetLastNoteData();
        driver.FindElement(By.CssSelector(path + " > div.views-container > div > textarea"));
        int k;
    }
}