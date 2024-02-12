using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patent patent = new Patent() 
            {
                Title="TheGreatPatent",
                Authors=new List<string>() { "TheGreatPatentAuthor1", "TheGreatPatentAuthor2" },
                DatePublised=DateTime.Now,
                ExpirationDate=DateTime.Now.AddDays(1),
                UIN = "123456789ABC",
            };

            Book book = new Book() 
            {
                ISBN="98765432A",
                Title="TheGreatBook",
                Authors = new List<string>() { "TheGreatBookAuthor1", "TheGreatBookAuthor2" },
                NumberOfPages=1,
                Publiser= "TheGreatBookPublisher",
                DatePublised= DateTime.Now
            };

            LocalizedBook localizedBook = new LocalizedBook() 
            {
                ISBN = "98765432B",
                Title = "TheGreatLocalizedBook",
                Authors = new List<string>() { "TheGreatLocalizedBookAuthor1" },
                NumberOfPages = 2,
                OriginalPubliser = "TheGreatBookOriginalPublisher",
                CountrOfLocalization="FarFarAway",
                LocalPubliser= "TheGreatBookLocalPublisher",
                DatePublised = DateTime.Now
            };
            Magazine magazine = new Magazine()
            {
                Id = "tR98765432A",
                Title = "TheGreatMagazine",
                Authors = new List<string>() { "TheGreatMagazineAuthor" },
                Publisher = "TheGreatMagazinePublisher",
                ReleaseNumber=1,
                DatePublised = DateTime.Now
            };

            StoreManagement.StoreInFile(patent);
            StoreManagement.StoreInFile(book);
            StoreManagement.StoreInFile(localizedBook);
            StoreManagement.StoreInFile(magazine);

            CMDInterfarce cmdInterfarce = new CMDInterfarce();
            cmdInterfarce.ShowInterface();

            //var cacheExp = new DateTimeOffset(new DateTime(2024, 1, 20, 7, 0, 0),new TimeSpan(0, 10, 0));

            //Document newPatent = StoreManagement.GetStoredFilesById<Patent>(patent.UIN);
            //Document newBook = StoreManagement.GetStoredFilesById<Book>(book.ISBN,true, cacheExp);
            //Document newLocalizedBook = StoreManagement.GetStoredFilesById<LocalizedBook>(localizedBook.ISBN);
            //Document newMagazine = StoreManagement.GetStoredFilesById<Magazine>(magazine.Id);

            //Document foundBook = StoreManagement.GetStoredFilesByName<Book>(newBook.Title);

        }
    }
}
