using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CsAsynchronousProgramming.Ingredients;

namespace CsAsynchronousProgramming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            SynchronousPreparation();
            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
            stopwatch.Reset();

            stopwatch.Start();
            await NonBlockingPreparation();
            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
            stopwatch.Reset();

            stopwatch.Start();
            await ConcurrentPreparation();
            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
            stopwatch.Reset();

            stopwatch.Start();
            await AwaitAllPreparation();
            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
            stopwatch.Reset();

            stopwatch.Start();
            await WhenAnyPreparation();
            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
            stopwatch.Reset();
        }

        private static void PrintElapsedTime(Stopwatch stopwatch)
        {
            TimeSpan timeSpan = stopwatch.Elapsed;
            Console.WriteLine("Run time: {0:00}:{1:00}:{2:00}.{3:00}\n",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
                timeSpan.Milliseconds / 10);
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
            Console.WriteLine("Synchronous breakfast is ready!");
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
            Console.WriteLine("Non-blocking breakfast is ready!");
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
            
            Console.WriteLine("Concurrent breakfast is ready!");
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
            Console.WriteLine("Await all breakfast is ready!");
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
            Console.WriteLine("When any breakfast is ready!");
        }
    }
}