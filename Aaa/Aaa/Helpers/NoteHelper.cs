using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Aaa;

public class NoteHelper:HelperBase
{

    public NoteHelper(ApplicationManager manager)
        : base(manager)
    {
    }
    
    public void AddNote()
    {
        //driver.Navigate().GoToUrl("https://www.bumajko.ru/#!/note/0/0/0/");
        driver.FindElement(By.XPath("//div[@id='block-top']/div/div/a[7]")).Click();
    }

    public void CreateNote(NoteData noteData)
    {
        AddNote();
        ChangeLastNote(noteData.Content);
    }
    
    public void ChangeLastNote(string keys)
    {
        string path = manager.Select.GetLastNoteData();
        var el = ReturnLastNote();
        el.Click();
        el.FindElement(By.CssSelector(".full")).SendKeys(keys);
        el.FindElement(By.CssSelector(".full")).SendKeys(Keys.Enter);
    }

    public string GetLastNoteData()
    {
        IList<IWebElement> elements = driver.FindElements(By.CssSelector(".notes-cont"));
        string[] values = new string[elements.Count];
        /*for (int i = 0; i < elements.Count; i++)
        {
            values[i] = elements[i].GetAttribute("id");
        }
        string str = values[elements.Count - 1];
        */
        string str = elements[elements.Count - 1].GetAttribute("id");
        return str;
    }

    public IWebElement ReturnLastNote()
    {
        var webElement = driver.FindElement(By.CssSelector("#"+ GetLastNoteData()));
        return webElement;
    }
    
    public void DeleteNote()
    {
        IList<IWebElement> elements = driver.FindElements(By.CssSelector("[note-data='n']"));
        string[] values = new string[elements.Count];
        for (int i = 0; i < elements.Count; i++)
        {
            values[i] = elements[i].GetAttribute("id");
        }
        
        string str = "[id='" + values[elements.Count - 1] + "']";
        var temp = driver.FindElement(By.CssSelector(str));
        
        driver.FindElement(By.CssSelector(str)).FindElement(By.CssSelector("[class='cmd-delete note-btn delete_img']")).Click();
        driver.FindElement(By.XPath("//div[@id='" + values[elements.Count - 1] + "']/div[3]/a")).Click();
        
    }
}