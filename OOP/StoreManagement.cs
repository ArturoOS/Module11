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
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(fileContent);
            }
        }
        public static T GetStoredFilesById<T>(string id, bool useCache = false, DateTimeOffset? dateTimeOffset = null)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "/");
            FileInfo[] files = dir.GetFiles("*"+id+".json");
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

        public static T GetStoredFilesByName<T>(string title) where T : new()
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "/");
            FileInfo[] files = dir.GetFiles("*.json");
            foreach (var file in files)
            {
                string docString = File.ReadAllText(file.FullName);
                Document newDocument = JsonConvert.DeserializeObject<Document>(docString);
                if (newDocument.Title == title)
                {
                    return JsonConvert.DeserializeObject<T>(docString);
                }
            }
            T notFound = new T();
            return notFound;
        }
    }
}
