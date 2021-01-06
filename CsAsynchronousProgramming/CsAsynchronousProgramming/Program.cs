using System;
using System.Collections.Generic;
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

            await ConcurrentPreparation();

            await AwaitAllPreparation();

            await WhenAnyPreparation();
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

        private static async Task ConcurrentPreparation()
        {
            Console.WriteLine("Concurrent breakfast preparation");
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
            
            Console.WriteLine("Concurrent breakfast is ready!\n");
        }

        private static async Task AwaitAllPreparation()
        {
            Console.WriteLine("Await all breakfast preparation");
            var cup = Coffee.PourCoffee();
            Console.WriteLine("coffee is ready");
    
            var eggsTask = Egg.FryEggsAsync(2);
            var baconTask = Bacon.FryBaconAsync(3);
            var toastTask = Toast.MakeToastWithButterAndJamAsync(2);

            await Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("eggs are ready");
            Console.WriteLine("bacon is ready");
            Console.WriteLine("toast is ready");

            Juice oj = Juice.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
            Console.WriteLine("Await all breakfast is ready!\n");
        }
        
        private static async Task WhenAnyPreparation()
        {
            Console.WriteLine("When any breakfast preparation");
            var cup = Coffee.PourCoffee();
            Console.WriteLine("coffee is ready");
    
            var eggsTask = Egg.FryEggsAsync(2);
            var baconTask = Bacon.FryBaconAsync(3);
            var toastTask = Toast.MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> {eggsTask, baconTask, toastTask};
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                } 
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                } 
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }
            
            Juice oj = Juice.PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
            Console.WriteLine("When any breakfast is ready!\n");
        }
    }
}