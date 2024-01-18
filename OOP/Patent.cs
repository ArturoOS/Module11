using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Patent : Document, IDocument
    {
        public string UIN { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Dictionary<string, string> GetInfoToStoreInFile()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            string path = Environment.CurrentDirectory + "/" + this.GetType().Name + "_" + this.UIN + ".json";
            var jsonString = JsonConvert.SerializeObject(this);
            info.Add(path, jsonString);
            return info;
        }
    }
}
