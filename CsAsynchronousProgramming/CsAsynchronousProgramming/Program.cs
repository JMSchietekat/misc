using System;
using System.Threading.Tasks;
using CsAsynchronousProgramming.Ingredients;

namespace CsAsynchronousProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            SynchronousPreparation();

            await NonBlockingPreparation();
        }

        static void SynchronousPreparation()
        {
            Console.WriteLine("Starting synchronous breakfast preparation");
            Coffee cup = Coffee.PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = Egg.FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = Bacon.FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = Toast.ToastBread(2);
            Toast.ApplyButter(toast);
            Toast.ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = Juice.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Synchronous breakfast is ready!");
        }

        static async Task NonBlockingPreparation()
        {   
            Console.WriteLine("Starting non blocking breakfast preparation");
            Coffee cup = Coffee.PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await Egg.FryEggsAsync(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = await Bacon.FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Toast toast = await Toast.ToastBreadAsync(2);
            Toast.ApplyButter(toast);
            Toast.ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = Juice.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Non-blocking breakfast is ready!");
        }
    }
}