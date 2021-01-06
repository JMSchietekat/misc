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

            await StartTaskConcurrently();
        }

        private static void SynchronousPreparation()
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
            Console.WriteLine("Synchronous breakfast is ready!\n");
        }

        private static async Task NonBlockingPreparation()
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
            Console.WriteLine("Non-blocking breakfast is ready!\n");
        }

        private static async Task StartTaskConcurrently()
        {
            Console.WriteLine("Starting tasks concurrently breakfast preparation");
            Coffee cup = Coffee.PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = Egg.FryEggsAsync(2);
            Task<Bacon> baconTask = Bacon.FryBaconAsync(3);
            Task<Toast> toastTask = Toast.ToastBreadAsync(2);

            Toast toast = await toastTask;
            Toast.ApplyButter(toast);
            Toast.ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = Juice.PourOJ();
            Console.WriteLine("oj is ready");
            
            Egg eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            
            Console.WriteLine("Starting tasks concurrently breakfast is ready!\n");
        }
    }
}