using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsIntermediate.Database;
using CsIntermediate.Workflow;
using CsIntermediate.Workflow.Activities;

namespace CsIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestPerson();
            // TestStopWatch();
            // TestStack();
            // TestDbConnection();
            TestWorkflowEngine();
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
            catch
            {
                Console.WriteLine("Stopwatch can't be started twice.");
            }
        }

        private static void TestStack()
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }

        private static void TestDbConnection()
        {
            var dbConncetions = new List<DbConnection>();
            dbConncetions.Add(new SqlServerConnection("sqlServerConnectionString"));
            dbConncetions.Add(new OracleConnection("oracleConnectionString"));
            
            foreach (var dbConnection in dbConncetions)
            {
                new DbCommand(dbConnection, "SELECT * FROM MASTER");
            }
        }

        private static void TestWorkflowEngine()
        {
            var workflowRunner = new WorkflowRunner();
            workflowRunner.Add(new UploadVideoToCloudStorageActivity());
            workflowRunner.Add(new PostToYoutubeActivity());
            workflowRunner.Run();
        }
    }
}