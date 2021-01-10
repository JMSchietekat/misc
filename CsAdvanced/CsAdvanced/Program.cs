using System;
using Interop = Interoperability.FSharp;

namespace CsAdvanced
{
    internal static class Program
    {
        private static void Main()
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
    }
}