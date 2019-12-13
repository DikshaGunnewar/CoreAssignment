using System;
using System.Collections.Generic;
using System.Text;

namespace CoreViewModel.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public float Salary { get; set; }
    }
}
