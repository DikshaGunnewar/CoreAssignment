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
    }
}