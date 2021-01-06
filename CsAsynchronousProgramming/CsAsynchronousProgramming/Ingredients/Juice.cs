using System;

namespace CsAsynchronousProgramming.Ingredients
{
    class Juice
    {
        public static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
    }
}