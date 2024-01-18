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
    public class LocalizedBook : Book
    {
        public string Name { get; set; }
        public string OriginalPubliser { get; set; }
        public string LocalPubliser { get; set; }
        public string CountrOfLocalization { get; set; }
    }
}
