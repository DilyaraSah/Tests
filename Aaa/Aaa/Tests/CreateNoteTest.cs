using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Aaa.Tests;

[TestFixture]
public class CreateNoteTest : AuthBase
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(NoteData));
    
    public static IEnumerable<NoteData> NoteFromXmlFile()
    {
        return (List<NoteData>) new XmlSerializer(typeof(List<NoteData>))
            .Deserialize(new FileStream(@"D:\ИТИС\3 КУРС\Тестирование\Aaa\note.xml", FileMode.OpenOrCreate));
    }
        
        
    [Test, TestCaseSource("NoteFromXmlFile")]
    public void CreateNote(NoteData noteData)
    {
        app.Select.CreateNote(noteData);
    }
}