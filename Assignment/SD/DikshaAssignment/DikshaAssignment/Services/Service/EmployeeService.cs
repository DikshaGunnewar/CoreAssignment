using DikshaAssignment.Services.Interface;
using DikshaAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DikshaAssignment.Repository;

namespace DikshaAssignment.Services.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityBaseRepository<Employee> _employeeRepository;
        
        public EmployeeService(IEntityBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
            
        }

        public Employee GetEmployeebyId(int? id)
        {
           return _employeeRepository.Get(id);
        }

        public async Task AddEmployee(Employee model)
        {
            await _employeeRepository.Create(model);
        }

        public async Task UpdateEmployee(Employee model)
        {
            await _employeeRepository.Update(model);
        }

        
         public void DeleteEmployeebyId(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
    }
}