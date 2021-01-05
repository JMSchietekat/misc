using System;

namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 1;
            int i = b;
            Console.WriteLine(i);

            int i2 = 300;
            byte b2 = (byte)i2;
            Console.WriteLine(b2);

            var number = "1234";
            int num = Convert.ToInt32(number);
            Console.WriteLine(num);

            try
            {
                var number2 = "2345";
                byte b3 = Convert.ToByte(number2);
                Console.WriteLine(b3);
            }
            catch (Exception e)
            {
                Console.WriteLine("Value was either too large or too small for an unsigned byte.");
            }
        }
    }
}