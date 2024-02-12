using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class StoreManagement
    {
        public static void StoreInFile(IDocument document)
        {
            var doc = document.GetInfoToStoreInFile();
            string filePath = doc.Keys.FirstOrDefault();
            string fileContent = doc.Values.FirstOrDefault();
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(fileContent);
                }
            }
        }
        public static T GetStoredFilesById<T>(string id, bool useCache = false, DateTimeOffset? dateTimeOffset = null)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "/");
            FileInfo[] files = dir.GetFiles("*"+id+".json");
            if (files.Count() > 0)
            {
                string docString = File.ReadAllText(files[0].FullName);
                if (useCache)
                {
                    ObjectCache cache = MemoryCache.Default;
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = dateTimeOffset.Value;
                    cache.Set("jsonString", docString, policy);
                }
                T newDocument = JsonConvert.DeserializeObject<T>(docString);
                return newDocument;
            }
            else
            {
                return default(T);
            }
        }

        public static List<T> GetStoredFilesByName<T>(string title) where T : new()
        {
            List<T> list = new List<T>();
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "/");
            FileInfo[] files = dir.GetFiles("*.json");
            foreach (var file in files)
            {
                string docString = File.ReadAllText(file.FullName);
                Document newDocument = JsonConvert.DeserializeObject<Document>(docString);
                if (newDocument.Title.ToLower().Contains(title.ToLower()))
                {
                    list.Add(JsonConvert.DeserializeObject<T>(docString));
                }
            }
            return list;
        }
    }
}
