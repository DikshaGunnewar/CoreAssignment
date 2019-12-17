using Microsoft.EntityFrameworkCore;
using DikshaAssignment.Models;

namespace DikshaAssignment.Models
{
    public class EmployeeDBContext : DbContext
    {
        // public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        // {
        // }
       DbSet<Employee> Employees { set; get; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlServer("server=SDNMS-DIKSHAP\\SQLEXPRESS; database=AssignmentDB;Trusted_Connection=True;");
       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, FirstName = "John", LastName="Watson", Designation = "Developer", Address = "New York", CompanyName = "XYZ Inc", EmailId = "john@yopmail.com", Salary = 30000, isActive = true },
                new Employee() { EmployeeId = 2, FirstName = "Elena", LastName="Snowball", Designation = "QA", Address = "North America", CompanyName = "Test Inc", EmailId = "elena@yopmail.com", Salary = 50000, isActive = true },
                new Employee() { EmployeeId = 3, FirstName = "Tom", LastName="William", Designation = "Deveploer", Address = "South America", CompanyName = "ABC Inc", EmailId = "tom@yopmail.com", Salary = 40000, isActive = true },
                new Employee() { EmployeeId = 4, FirstName = "Suzi", LastName="Cook", Designation = "UI Developer", Address = "London", CompanyName = "Lol Inc", EmailId = "suzi@yopmail.com", Salary = 35000, isActive = true }
                );
        }
    }
}