using ClassLibraryNetCore;
using System;

namespace TestLibraryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TryPersonsContext();
        }
        static void TryPersonsContext()
        {
            using (var context = new PersonsContext())
            {
                var person1 = new Person
                {
                    FirstName = "Alexandra",
                    MiddleName = "Ioana",
                    LastName = "Ghidersa",
                    TelephoneNumber = "0789369548"
                };
                var person2 = new Person
                {
                    FirstName = "Ana",
                    MiddleName = "Maria",
                    LastName = "Popescu",
                    TelephoneNumber = "0789309549"
                };
                context.People.AddRange(new Person[] { person1, person2 });
                context.SaveChanges();
                foreach (var person in context.People)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
