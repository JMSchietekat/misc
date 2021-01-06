using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise1();
            // Exercise2();
            // Exercise3();
            // Exercise4();
            Exercise5();
        }

        private static void Exercise1()
        {
            /*
             * 1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder.
             * Display the count on the console.
             */
            var count = 0;
            for(int i = 1; i< 100; i++)
                if (i % 3 == 0)
                    count++;

            Console.WriteLine(count);
        }

        private static void Exercise2()
        {
            /*
             * 2- Write a program and continuously ask the user to enter a number or "ok" to exit.
             * Calculate the sum of all the previously entered numbers and display it on the console.
             */
            var sum = 0;
            while (true)
            {
                Console.Write("Enter a number to be tallied. 'ok' to exit.: ");
                var res = Console.ReadLine();

                if (res.ToLower().Equals("ok"))
                    break;
                else
                    sum += Int32.Parse(res);
            }

            Console.WriteLine($"The sum is {sum}");
        }

        private static void Exercise3()
        {
            /*
             * 3- Write a program and ask the user to enter a number. Compute the factorial of the number and
             * print it on the console. For example, if the user enters 5, the program should calculate
             * 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
             */
            Console.WriteLine("Enter a number: ");
            var input = Console.ReadLine();
            Console.WriteLine("{0}! = {1}", input, Factorial(Int32.Parse(input)));
        }

        private static int Factorial(int input) => input == 1 ? 1 : input * Factorial(input - 1);
        
        private static void Exercise4()
        {
            /*
             * 4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess
             * the number. If the user guesses the number, display “You won"; otherwise, display “You lost".
             * (To make sure the program is behaving correctly, you can display the secret number on the console first.)
             */
            var random = new Random();
            var secret = random.Next(1, 10);
            var chances = 4;

            while (chances > 0)
            {
                Console.Write("Guess the secret number: ");
                var guess = Int32.Parse(Console.ReadLine());

                if (guess == secret)
                {
                    Console.WriteLine("You won");
                    break;
                }

                if (--chances != 0) continue;
                
                Console.WriteLine("You lost");
                break;
            }

            Console.WriteLine($"Secret number was {secret}.");
        }

        private static void Exercise5()
        {
            /*
             * 5- Write a program and ask the user to enter a series of numbers separated by comma.
             * Find the maximum of the numbers and display it on the console. For example, if the user
             * enters “5, 3, 8, 1, 4", the program should display 8.
             */

            Console.Write("Enter a series of numbers separated by commas: ");
            var input = Console.ReadLine();

            var inputArr = input.Split(',');

            var max = 0;
            foreach(var stringValue in inputArr)
            {
                var intValue = Int32.Parse(stringValue);
                if (max < intValue)
                    max = intValue;
            }

            Console.WriteLine($"The maximum value is {max}.");
        }
        
    }
}