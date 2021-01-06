using System;

namespace CsIntermediate
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; private set; }
        
        public Person(DateTime birthdate)
        {
            Birthdate = birthdate;
        }
        public int Age
        {
            get
            {
                var span = DateTime.Today - Birthdate;
                return span.Days / 365;
            }
        }

        
    }
}