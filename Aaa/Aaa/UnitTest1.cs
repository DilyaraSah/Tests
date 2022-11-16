using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Xml.Serialization;

namespace Aaa
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        AccountData user = new AccountData("admin", "secret");

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(NoteData));
    
        public static IEnumerable<NoteData> NoteFromXmlFile()
        {
            return (List<NoteData>) new XmlSerializer(typeof(List<NoteData>))
                .Deserialize(new FileStream(@"C:\Users\Владислава\Desktop\note.xml", FileMode.OpenOrCreate));
        }
        
        
        [Test, TestCaseSource("NoteFromXmlFile")]
        public void TheUntitledTestCaseTest(NoteData noteData)
        {
            Thread.Sleep(1000);
            app.Navigation.OpenHomePage();
            app.Auth.Login(user);
            Thread.Sleep(1000);
            /**/
            app.Navigation.OpenHomePage();
            app.Select.AddNote();
            Thread.Sleep(1000);
            app.Select.ChangeLastNote(noteData.Content);
            Thread.Sleep(1000);
            app.Stop();
            
            
        }

    }
}
