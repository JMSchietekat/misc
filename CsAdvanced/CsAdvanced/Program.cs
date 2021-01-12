using System;
using System.Linq;
using Interop = Interoperability.FSharp;

namespace CsAdvanced
{
    internal static class Program
    {
        private static void Main()
        {
            RunInteroperabilitySample();
            RunExtensionMethodsSample();
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
    }
}