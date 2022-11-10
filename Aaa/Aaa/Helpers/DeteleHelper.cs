using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Aaa;

public class DeleteHelper:HelperBase
{
    public DeleteHelper(ApplicationManager manager)
        : base(manager)
    {
    }
    
    public void DeleteNote()
    {
        //driver.Navigate().GoToUrl("https://www.bumajko.ru/#!/note/0/0/0/");
        /*driver.FindElement(By.CssSelector("a.cmd-delete.note-btn.delete_img > svg > path")).Click();*/
        //driver.FindElement(By.XPath("//div[@id='noteid33334']/div[3]/a")).Click();
        
        IList<IWebElement> elements = driver.FindElements(By.CssSelector("[note-data='n']"));
        string[] values = new string[elements.Count];
        for (int i = 0; i < elements.Count; i++)
        {
            values[i] = elements[i].GetAttribute("id");
        }
        
        string str = "[id='" + values[elements.Count - 1] + "']";
        var temp = driver.FindElement(By.CssSelector(str));
        
        driver.FindElement(By.CssSelector(str)).FindElement(By.CssSelector("[class='cmd-delete note-btn delete_img']")).Click();
        //driver.FindElement(By.CssSelector("a.cmd-delete.note-btn.delete_img > svg > path")).Click();
        driver.FindElement(By.XPath("//div[@id='" + values[elements.Count - 1] + "']/div[3]/a")).Click();
        //List<IWebElement> notes = new List<IWebElement>(); 

        //var noteId = driver.FindElement(By.ClassName("notes-count ed-0 ng-class:{'fullscreen':item.modeFullscreen}"));

        //getElementAttribute(noteId, 'id');
        //getElementAttribute("noteId");
        /*driver.FindElement(By.XPath("//div[@id='noteid33364']/div[2]/div/textarea")).Click();
        driver.FindElement(By.XPath("//div[@id='noteid33364']/div[2]/div/textarea")).Clear();
        driver.FindElement(By.XPath("//div[@id='noteid33364']/div[2]/div/textarea")).SendKeys("aaa");*/
    }
}