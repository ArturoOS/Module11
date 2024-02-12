using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class CMDInterfarce : IUserInterface
    {
        public void ShowInterface()
        {
            Console.WriteLine("DOCUMENTS SEARCHER");
            while (true) 
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your reaseach:");
                string document = Console.ReadLine();

                var foundDocumentList = StoreManagement.GetStoredFilesByName<Document>(document);
                if (foundDocumentList.Count == 0)
                {
                    Document foundDocument = StoreManagement.GetStoredFilesById<Document>(document);
                    if (foundDocument == null)
                    {
                        Console.WriteLine("File not found");
                    }
                    else
                    {
                        Console.WriteLine("File found:");
                        Console.WriteLine("Tile: " + foundDocument.Title);
                        foreach (var author in foundDocument.Authors)
                        {
                            Console.WriteLine("Author: " + author);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Files found:");
                    foreach (var foundDocument in foundDocumentList)
                    {
                        Console.WriteLine("Tile: " + foundDocument.Title);
                        foreach (var author in foundDocument.Authors)
                        {
                            Console.WriteLine("Author: " + author);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
