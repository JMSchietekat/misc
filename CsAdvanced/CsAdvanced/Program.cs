using System;
using System.Collections.Generic;
using System.Linq;
using Interop = Interoperability.FSharp;

namespace CsAdvanced
{
    internal static class Program
    {
        private static void Main()
        {
            // RunInteroperabilitySample();
            // RunExtensionMethodsSample();
            RunLinqSample();
        }
        

        private static void RunInteroperabilitySample()
        {
            var login = new Interop.Login(42, "connel", "password");
            PrintWelcomeMessage(login);
            Console.ReadLine();
        }

        private static void PrintWelcomeMessage(Interop.ILogin login)
        {
            if (login.IsValid)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Failed to log in");
            }
        }

        private static void RunExtensionMethodsSample()
        {
            var post = "This is a very long post blah blah blah...";
            var shortenedPost = post.Shorten(5);

            Console.WriteLine(shortenedPost);
        }

        private static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords <= 0)
                throw new ArgumentOutOfRangeException($"Paramater 'numberOfWords' should be more than zero.");

            var words = str.Split(" ");

            if (words.Length <= numberOfWords)
                return str;

            return string.Join(" ", words.Take(numberOfWords)) + "...";
        }

        private static void RunLinqSample()
        {
            var books = new BookRepository().GetBooks();
            
            // LINQ Query operators
            var cheaperBooks =
                from b in books
                where b.Price < 10
                orderby b.Title
                select b.Title;

            // LINQ Extension Methods
            var cheapBooks = books
                .Where(b => b.Price < 10)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);
                

            foreach (var book in cheapBooks)
                Console.WriteLine(book); 
            
            foreach (var book in cheaperBooks)
                Console.WriteLine(book);
        }

        

        
    }
}