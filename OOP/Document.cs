using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP
{
    public class Document
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime DatePublised { get; set; }
    }
}
