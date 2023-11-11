using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltasBookStoreAppWebAPI.Models;
namespace DeltasBookStoreAppWebAPITest.MockData
{
    public class BookDetailsMock
    {
        public static List<BookDetails> GetBooks()
        {
            return new List<BookDetails>
            {
               new BookDetails
               {
                   Id = 1,
                   BookName = "Test",
                   AuthorName="Test1",
                   PublishedDate="07-11-2023",
                   BookDescription="Test XYZ",
                   PublisherName="Test Publisher",
                   TotalCopiesSold=100,
                   Price=100,
                   IsActive="Y"
               },
                new BookDetails
                {
                   Id = 2,
                   BookName = "Test2",
                   AuthorName="Test3",
                   PublishedDate="06-11-2023",
                   BookDescription="Test ABC",
                   PublisherName="Test1 Publisher",
                   TotalCopiesSold=200,
                   Price=300,
                   IsActive="Y"
               },
                 new BookDetails
                 {
                   Id = 3,
                   BookName = "Test3",
                   AuthorName="Test11",
                   PublishedDate="05-11-2023",
                   BookDescription="Test DSA",
                   PublisherName="Test2 Publisher",
                   TotalCopiesSold=300,
                   Price=250,
                   IsActive="Y"
               }
            };
        }

        public static List<BookDetails> GetDeletedBooks()
        {
            return new List<BookDetails>
            {
               new BookDetails
               {
                   Id = 1,
                   BookName = "Test",
                   AuthorName="Test1",
                   PublishedDate="07-11-2023",
                   BookDescription="Test XYZ",
                   PublisherName="Test Publisher",
                   TotalCopiesSold=100,
                   Price=100,
                   IsActive="N"
               },
                new BookDetails
                {
                   Id = 2,
                   BookName = "Test2",
                   AuthorName="Test3",
                   PublishedDate="06-11-2023",
                   BookDescription="Test ABC",
                   PublisherName="Test1 Publisher",
                   TotalCopiesSold=200,
                   Price=300,
                   IsActive="N"
               },
                 new BookDetails
                 {
                   Id = 3,
                   BookName = "Test3",
                   AuthorName="Test11",
                   PublishedDate="05-11-2023",
                   BookDescription="Test DSA",
                   PublisherName="Test2 Publisher",
                   TotalCopiesSold=300,
                   Price=250,
                   IsActive="N"
               }
            };
        }
    }
}
