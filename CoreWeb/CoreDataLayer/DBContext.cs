using CoreDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDataLayer
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Employee> Employees { set; get; }

        // added to write the seed data into the table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, Name = "John", Designation = "Developer", Address = "New York", CompanyName = "XYZ Inc", EmailId = "john@yopmail.com", Salary = 30000, isActive = true },
                new Employee() { EmployeeId = 2, Name = "Elena", Designation = "QA", Address = "North America", CompanyName = "Test Inc", EmailId = "elena@yopmail.com", Password = "Password", Salary = 50000, isActive = true },
                new Employee() { EmployeeId = 3, Name = "Tom", Designation = "Deveploer", Address = "South America", CompanyName = "ABC Inc", EmailId = "tom@yopmail.com", Password = "Password", Salary = 40000, isActive = true },
                new Employee() { EmployeeId = 4, Name = "Suzi", Designation = "UI Developer", Address = "London", CompanyName = "Lol Inc", EmailId = "suzi@yopmail.com", Password = "Password", Salary = 35000, isActive = true }
                );
        }
    }
}
