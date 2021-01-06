using System;

namespace CsAsynchronousProgramming.Ingredients
{
    class Coffee
    {
        public static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}