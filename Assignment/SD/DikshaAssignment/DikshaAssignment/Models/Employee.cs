using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DikshaAssignment.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public float Salary { get; set; }
        public bool isActive { get; set; }
    }
}
