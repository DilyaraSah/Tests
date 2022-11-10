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
    
    public NoteData GetCreatedNoteData()
    {
        string idName = driver.FindElement(By.ClassName("notes-cont.ed-0.ng-class:{'fullscreen':item.modeFullscreen}")).GetAttribute("id");
        return new NoteData(idName);
    }

    public void SelectLastCSelectLastCreatedNote()
    {
        IList<IWebElement> elements = driver.FindElements(By.CssSelector("[class='notes-cont ed-0 ng-class:{'fullscreen':item.modeFullscreen}']"));
        string[] values = new string[elements.Count];
        for (int i = 0; i < elements.Count; i++)
        {
            values[i] = elements[i].GetAttribute("id");
        }
        string str = "[id='" + values[elements.Count - 1] + "']";
        driver.FindElement(By.CssSelector(str)).Click();
    }

    public string GetLastNoteData()
    {
        IList<IWebElement> elements = driver.FindElements(By.CssSelector("[class='notes-cont ed-0 ng-class:{'fullscreen':item.modeFullscreen}']"));
        string[] values = new string[elements.Count];
        for (int i = 0; i < elements.Count; i++)
        {
            values[i] = elements[i].GetAttribute("id");
        }
        string str = values[elements.Count - 1];
        return str;
    }
}