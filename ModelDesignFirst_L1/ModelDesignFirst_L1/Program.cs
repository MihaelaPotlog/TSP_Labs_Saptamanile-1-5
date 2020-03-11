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
            // TestPerson();
            // TestOneToMany();
            // TestManyToMany();
            TestDoctorPacientContext();
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

        static void TestManyToMany()
        {
            Console.WriteLine("\nMany to many association");

            using (ModelManyToManyContainer context =
                new ModelManyToManyContainer())
            {
                Console.WriteLine("FirstName:");
                Console.WriteLine("LastName:");

                Artist artist1 = new Artist()
                {

                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine()
                };

                Console.WriteLine("Album Name");
                Album album1 = new Album()
                {
                    Name = Console.ReadLine(),
                    Artists = new List<Artist>() { artist1}
                };

                Console.WriteLine("Album Name");
                Album album2 = new Album()
                {
                    Name = Console.ReadLine(),
                    Artists = new List<Artist>() { artist1 }
                };

                context.Artists.Add(artist1);
                context.Albums.Add(album1);
                context.Albums.Add(album2);
                context.SaveChanges();

                foreach (var artist in context.Artists)
                {
                    Console.WriteLine("Name: {0} {1}", artist.FirstName, artist.LastName);
                    foreach (var album in artist.Albums)
                    {
                        Console.WriteLine("Album: {0} Id: {1}", album.Id, album.Name);
                    }
                }
            }
        }

        static void TestDoctorPacientContext()
        {
            Console.WriteLine("\nMany to many association");

            using (DoctorPatientContainer context =
                new DoctorPatientContainer())
            {
                Console.WriteLine("Many to many assosiation( database first)");
                Console.WriteLine("FirstName + LastName + Specialty:\n");
                Doctor doctor1 = new Doctor()
                {
                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine(),
                    Specialty = Console.ReadLine()
                };
                
                Console.WriteLine("FirstName + LastName:\n");
                Pacient pacient1 = new Pacient()
                {
                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine()
                };
                
                Console.WriteLine("FirstName + LastName:\n");
                Pacient pacient2 = new Pacient()
                {
                    FirstName = Console.ReadLine(),
                    LastName = Console.ReadLine()
                };
                
                DoctorPacient doctorPacient1 = new DoctorPacient()
                {
                    Date = DateTime.Now,
                    Pacient = pacient1,
                    Doctor = doctor1
                };
                DoctorPacient doctorPacient2 = new DoctorPacient()
                {
                    Date = DateTime.Now,
                    Pacient = pacient2,
                    Doctor = doctor1
                };
                context.Pacients.Add(pacient1);
                context.Pacients.Add(pacient2);
                context.Doctors.Add(doctor1);
                context.DoctorPacients.Add(doctorPacient1);
                context.DoctorPacients.Add(doctorPacient2);
                context.SaveChanges();

                foreach (var doctor in context.Doctors)
                {
                    Console.WriteLine("Doctor:  {0} ", doctor);

                    foreach (var doctorPacient in doctor.DoctorPacients)
                    {
                        Console.WriteLine("Pacient: {0}", doctorPacient.Pacient);
                    }
                }

            }
        }
    }
}


