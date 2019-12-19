using DikshaAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DikshaAssignment.Services.Interface
{
    public interface IEmployeeService
    {

        /// <summary>
        /// Service to get all employee records.
        /// </summary>
        /// <returns></returns>
        IQueryable <Employee> GetAllEmployees();

        /// <summary>
        /// Service to get employee by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeebyId(int? id);

        /// <summary>
        /// Service to insert the new record 
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        Task AddEmployee(Employee model);

        /// <summary>
        /// Service to update the existing record.
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        Task UpdateEmployee(Employee model);

        /// <summary>
        /// Service to delete the record.
        /// </summary>
        /// <param name="employee">employee</param>
        void DeleteEmployeebyId(Employee employee);
    }
}