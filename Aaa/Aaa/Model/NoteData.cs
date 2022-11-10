using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa;

public class NoteData
{
    public NoteData()
    {
        
    }

    public NoteData(string content)
    {
        Content = content;
    }
    public string Id {get; set;}
    public string Content { get; set; }
}