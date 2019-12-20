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
        
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        // [StringLength(100, ErrorMessage = "Address can not be loner then 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Company is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public float Salary { get; set; }

        public bool isActive { get; set; }
    }
}
