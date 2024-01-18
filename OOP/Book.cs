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
    public class Book : Document, IDocument
    {
        public string ISBN { get; set; }
        public string Publiser { get; set; }
        public Dictionary<string, string> GetInfoToStoreInFile()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            string path = Environment.CurrentDirectory + "/" + this.GetType().Name + "_" + this.ISBN + ".json";
            var jsonString = JsonConvert.SerializeObject(this);
            info.Add(path, jsonString);
            return info;
        }
    }
}
