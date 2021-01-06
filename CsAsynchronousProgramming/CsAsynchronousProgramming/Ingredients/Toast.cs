using System;
using System.Threading.Tasks;

namespace CsAsynchronousProgramming.Ingredients
{
    class Toast
    {
        public static void ApplyJam(Toast toast) => Console.WriteLine("Putting jam on the toast");

        public static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on the toast");
        public static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }
        
        public static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }
    }
}