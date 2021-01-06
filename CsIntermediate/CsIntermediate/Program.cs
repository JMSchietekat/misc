using System;
using System.Threading;
using System.Threading.Tasks;

namespace CsIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestPerson();
            TestStopWatch();
        }

        private static void TestPerson()
        {
            var person = new Person(new DateTime(1990,2,1));
            Console.WriteLine($"Age: {person.Age}");
        }

        private static void TestStopWatch()
        {
            var stopwatch = new StopWatch();

            Console.WriteLine("Time first 3 second task.");
            stopwatch.Start();
            Thread.Sleep(3000);
            stopwatch.Stop();
            Console.WriteLine($"Duration: {stopwatch.Duration().Seconds} seconds");

            Console.WriteLine("Time another 2 second task");
            stopwatch.Start();
            Thread.Sleep(2000);
            stopwatch.Stop();
            Console.WriteLine($"Duration: {stopwatch.Duration().Seconds} seconds");

            try
            {
                Console.WriteLine("Time another 4 second task but start the timer twice");
                stopwatch.Start();
                stopwatch.Start();
                Thread.Sleep(4000);
                stopwatch.Stop();
                Console.WriteLine($"Duration: {stopwatch.Duration().Seconds} seconds");
            }
            catch (Exception e)
            {
                Console.WriteLine("Stopwatch can't be started twice.");
            }
            
            
            
            
        }
    }
}