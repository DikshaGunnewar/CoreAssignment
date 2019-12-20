using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DikshaAssignment.Models; 
using DikshaAssignment.Repository;

namespace DikshaAssignment.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEntityBaseRepository<Employee> _ientitybaserepository;
        

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="ientitybaserepository"></param>
        public UserController(IEntityBaseRepository<Employee> ientitybaserepository)
        {
            _ientitybaserepository = ientitybaserepository;
        }

        // GET api/user
        /// <summary>
        /// This method is used to get all the records.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try {
                   var employeeList = _ientitybaserepository.GetAll();
                   if (employeeList.Any())
                      return Ok(employeeList);
                   else
                    return NotFound();
            } catch (Exception) {
                return StatusCode(500);
            }
           
        }

        /// <summary>
        /// This method is used to get the single record.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet("GetstringById/id")]
        public IActionResult GetstringById(int? id)
        {
            try {
                if (id == null){
                    return BadRequest();
                }
                Employee employee = _ientitybaserepository.Get(id);
    
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
                   
            } catch (Exception) {
                return StatusCode(500);
            }
           
        }


        /// <summary>
        /// This method is used to add a new record.
        /// </summary>
        /// <param name="employee">employee</param>
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try {
                    if (employee == null) {
                        return BadRequest ("Invalid model passed.");
                    }
                    if (ModelState.IsValid) {
                        await _ientitybaserepository.Create (employee);
                        return Ok(200);
                    }

                } catch (Exception) {
                    return StatusCode (500);
                }
            return NotFound();
        }

        /// <summary>
        /// To method is used to update the existing record.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="employee">employee</param>
        /// <returns></returns>
        [HttpPost ("UpdateEmployee/id")]
        public async Task<IActionResult> UpdateEmployee(int? id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ientitybaserepository.Update(employee);
                    return Ok(200);
                }
                catch (Exception)
                {  
                    var employeeExist = _ientitybaserepository.Get(employee.EmployeeId);
                        if (employeeExist == null)
                        {
                            return NotFound();
                        } else
                        {
                            return StatusCode(500);
                        }
                }
               
            }
            return NoContent();
        }
        /// <summary>
        /// To method is used to update the existing record.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        // [HttpPost ("updateEmployee/id")]
        // public IActionResult updateEmployee (int? id) 
        // {

        //     if (id == null)
        //     {
        //         return BadRequest("Invaild model passed");
        //     }
        //     Employee employee = _ientitybaserepository.Get(id);
        //     if (employee == null) {
        //          return NotFound();
        //     }
        //     _ientitybaserepository.Update(employee);
        //     return Ok (200);
           
        // }

        
        /// <summary>
        /// This method is used to delete the record.
        /// </summary>
        /// <param name="id">id</param>
        [HttpDelete("DeleteEmployeeById/id")]
        public IActionResult DeleteEmployeeById(int? id)
        {
            if(id == null){
                return BadRequest();
            }
            try {
                Employee employee = _ientitybaserepository.Get(id);

                if(employee == null){
                     return NotFound ();
                }
                 _ientitybaserepository.Delete(employee);
                return Ok(200);
            } catch (Exception) {
                return StatusCode (500);
            }
        }
    }
}