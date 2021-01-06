using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise1();
            // Exercise2();
            Exercise3();
        }

        static void Exercise1()
        {
            /*
             * 1- When you post a message on Facebook, depending on the number of people who like your post,
             * Facebook displays different information.
                If no one likes your post, it doesn't display anything.
                If only one person likes your post, it displays: [Friend's Name] likes your post.
                If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
                If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.

             * Write a program and continuously ask the user to enter different names, until the user presses
             * Enter (without supplying a name). Depending on the number of names provided, display a message
             * based on the above pattern.
             */

            Console.WriteLine(GetPostMessage(AskUserForNames()));
        }
        
        static List<string> AskUserForNames()
        {
            var names = new List<string>();

            while (true)
            {
                Console.Write("Enter a name. Submit nothing to continue: ");
                var res = Console.ReadLine();
                if (res.Equals(""))
                    break;
                
                names.Add(res);
            }

            return names;
        }

        static string GetPostMessage(List<string> names)
        {
            return names.Count switch
            {
                0 => "",
                1 => $"{names[0]} likes your post.",
                2 => $"{names[0]} and {names[1]} like your post.",
                _ => $"{names[0]}, {names[1]} and {names.Count - 2} others like your post."
            };
        }

        static void Exercise2()
        {
            /*
             * 2- Write a program and ask the user to enter their name. Use an array to reverse the name
             * and then store the result in a new string. Display the reversed name on the console.
             */
            Console.Write("Enter a name. Submit nothing to continue: ");
            var name = Console.ReadLine();

            var charArr = name.ToCharArray();
            var charArr2 = new char[name.Length];
            
            Array.Reverse(charArr);
            Array.Copy(charArr, charArr2, name.Length);

            var name2 = new string(charArr2);

            Console.WriteLine(name2);

        }

        static void Exercise3()
        {
            /*
             * 3- Write a program and ask the user to enter 5 numbers. If a number has been previously entered,
             * display an error message and ask the user to re-try. Once the user successfully enters 5 unique
             * numbers, sort them and display the result on the console.
             */
        }static void Exercise4()
        {
            /*
             * 4- Write a program and ask the user to continuously enter a number or type "Quit" to exit.
             * The list of numbers may include duplicates. Display the unique numbers that the user has entered.
             */
        }static void Exercise5()
        {
            /*
             * 5- Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10).
             * If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user
             * to re-try; otherwise, display the 3 smallest numbers in the list.
             */
        }
    }
}