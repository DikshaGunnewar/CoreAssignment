using DikshaAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DikshaAssignment.Services.Interface
{
    public interface IEmployeeService
    {
        IQueryable <Employee> GetAllEmployees();

        Employee GetEmployeebyId(int? id);

        Task AddEmployee(Employee model);
        Task UpdateEmployee(Employee model);

        void DeleteEmployeebyId(Employee employee);
    }
}