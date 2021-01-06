using System;
using NonPrimitiveTypes.Math;

namespace NonPrimitiveTypes
{
    public enum ShippingMethod
    {
        RegularAirMail = 0,
        RegisteredAirMail = 1,
        Express = 2
    }

    public delegate int Function(int input);
    
    class Program
    {
        static void Main(string[] args)
        {
            // Class
            var person = new Person();
            person.FirstName = "Justin";
            person.LastName = "Schietekat";
            person.Introduce();
            
            var res = Calculator.Add(5);
            Console.WriteLine(res);
            res = Calculator.Add(3);
            Console.WriteLine(res);
    
            // Array
            var numbers = new int[3];

            // Enum
            var method = ShippingMethod.RegularAirMail;
            Console.WriteLine(method);

            // Delegates
            Calculator.Clear();
            
            Function fn;
            Function fn1 = Calculator.Add;
            Function fn2 = Calculator.Multiply;

            fn = fn1;
            fn += fn2;
            fn += fn2;

            Console.WriteLine(fn(5));
            
            // Reference vs Value types
        }
    }
}