using CoreDataLayer.Models;
using CoreViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Interface
{
    public interface IEmployeeService
    {

        IQueryable <Employee> GetAllEmployees();

        Employee GetEmployeebyId(int postId);

        Task AddEmployee(Employee model);
        Task UpdateEmployee(Employee model);

        void DeleteEmployeebyId(int id);

       
    }
}
