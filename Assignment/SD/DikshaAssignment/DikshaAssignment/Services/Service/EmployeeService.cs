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
        
        /// <summary>
        /// Default Constructor created
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeService(IEntityBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        /// <summary>
        /// This Service is used to get the all records.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
            
        }

        /// <summary>
        /// This service is used to get the record by using id.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Employee GetEmployeebyId(int? id)
        {
           return _employeeRepository.Get(id);
        }


        /// <summary>
        /// This service is used to insert the new record.
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public async Task AddEmployee(Employee model)
        {
            await _employeeRepository.Create(model);
        }

        /// <summary>
        /// This service is used to update the existig record.
        /// </summary>
        /// <param name="model">model</param>`
        /// <returns></returns>
        public async Task UpdateEmployee(Employee model)
        {
            await _employeeRepository.Update(model);
        }

        
        /// <summary>
        /// This service is used to delete the record.
        /// </summary>
        /// <param name="employee">employee</param>
         public void DeleteEmployeebyId(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
    }
}