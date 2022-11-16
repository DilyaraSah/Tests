// See https://aka.ms/new-console-template for more information

using System.Xml.Serialization;
using Aaa;

XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<NoteData>));
List<NoteData> data = new List<NoteData>();
Random random = new Random();
const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
string content = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
data.Add(new NoteData(content));
using(FileStream fs = new FileStream(@"C:\Users\Владислава\Desktop\note.xml", FileMode.OpenOrCreate))
{
    xmlSerializer.Serialize(fs, data);
    Console.WriteLine("object serialized");
}