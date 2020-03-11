using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            TestPerson();
            TestOneToMany();
            Console.ReadKey();
        }

        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                Person p = new Person()
                {
                    FirstName = "Julie",
                    LastName = "Andrew",
                    MiddleName = "T",
                    TelephoneNumber = "1234567890"
                };
                context.People.Add(p);
                context.SaveChanges();

                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        static void TestOneToMany()
        {
            Console.WriteLine("One to many association");
            using (ModelOneToManyContainer context =
                new ModelOneToManyContainer())
            {
                Console.WriteLine("Name:");
                Console.WriteLine("City:");

                Customer c = new Customer()
                {
                    Name = Console.ReadLine(),
                    City = Console.ReadLine()
                };

                Console.WriteLine("TotalValue:");
               
                Order o1 = new Order()
                {
                    TotalValue = Int32.Parse(Console.ReadLine()),
                    Date = DateTime.Now,
                    Customer = c
                };

                Console.WriteLine("TotalValue:");
                
                Order o2 = new Order()
                {
                    TotalValue = Int32.Parse(Console.ReadLine()),
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();

                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                        x.Id, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                            ox.Id, ox.Date, ox.TotalValue);
                }
            }
        }
    }
}


