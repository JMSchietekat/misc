using System.Collections.Generic;

namespace CsAdvanced
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book() {Title = "ADO.Net Step by step", Price = 5},
                new Book() {Title = "ASP.NET MVC", Price = 9.99f},
                new Book() {Title = "ASP.NET Web Api", Price = 12},
                new Book() {Title = "C# Advanced Topics", Price = 7},
                new Book() {Title = "C# Advanced Topics", Price = 9}
            };
        }
    }
}