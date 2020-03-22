using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryNetCore
{
    public sealed class PersonsContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public PersonsContext()
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCoreLabDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(person => person.FirstName).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Person>().Property(person => person.LastName).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Person>().Property(person => person.MiddleName).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Person>().Property(person => person.TelephoneNumber).HasMaxLength(10).IsRequired();

        }
    }
}
