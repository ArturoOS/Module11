using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Magazine:Document, IDocument
    {
        public string Id { get; set; }
        public string Publisher { get; set; }
        public int ReleaseNumber { get; set; }

        public Dictionary<string, string> GetInfoToStoreInFile()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            string path = Environment.CurrentDirectory + "/" + this.GetType().Name + "_" + this.Id + ".json";
            var jsonString = JsonConvert.SerializeObject(this);
            info.Add(path, jsonString);
            return info;
        }
    }
}
