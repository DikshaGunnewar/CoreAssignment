using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DikshaAssignment.Models;
using DikshaAssignment.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DikshaAssignment.Controllers {
    public class EmployeeController : Controller {
        private readonly IEmployeeService _iemployeeservice;

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeController (IEmployeeService iemployeeservice) {
            _iemployeeservice = iemployeeservice;
        }

        public IActionResult Index () {
            var data = _iemployeeservice.GetAllEmployees ();
            return View (data);
        }

        //    public async Task<IActionResult> Details(int? id)
        //     {
        //         if (id == null)
        //         {
        //             return NotFound();
        //         }

        //         var data = await _iemployeeservice.GetEmployeebyId(id);

        //         if (data == null)
        //         {
        //             return NotFound();
        //         }

        //         return View(data);
        //     }
        [HttpGet]
        public ActionResult Create () {
            return View ();
        }

        /// <summary>
        /// This API is used to insert the record into db collection.
        /// </summary>
        /// <param name="employee">Employee input model</param>
        /// <returns></returns>
        [HttpPost, ActionName ("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind] Employee employee) {
            try {

                    if (employee == null) {
                        return BadRequest ("Invalid model passed.");
                    }
                    if (ModelState.IsValid) {
                        await _iemployeeservice.AddEmployee (employee);
                        return RedirectToAction (nameof (Index));
                    }

                } catch (Exception) {
                    return StatusCode (500);
                }
            return View (employee);
        }

        /// <summary>
        /// To get the edit view
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit (int? id) {

            if (id == null)
            {
                return BadRequest("Invaild model passed");
            }
            Employee employee = _iemployeeservice.GetEmployeebyId(id);
            if (employee == null) {
                 return NotFound();
            }
            return View (employee);
           
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit ([Bind] Employee employee) {
            try {
                if (ModelState.IsValid) {
                    await _iemployeeservice.UpdateEmployee(employee);
                    return RedirectToAction ("Index");
                }
                return View (employee);

            } catch (Exception) {
                return StatusCode (500);
            }
        }

        /// <summary>
        /// To get the delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        // public ActionResult Delete (int? id) {
        //     try {
        //         Employee employee = _iemployeeservice.GetEmployeebyId (id);
        //         if (employee == null) {
        //             return NotFound ();
        //         }
        //         return View (employee);
        //     } catch (Exception) {
        //         return StatusCode (500);
        //     }
        // }

        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int? id) {
            if (id == null) {
                    return BadRequest ("Invalid data model passed");
              }
            try {
                Employee employee = _iemployeeservice.GetEmployeebyId(id);

                if(employee == null){
                     return NotFound ();
                }
                 _iemployeeservice.DeleteEmployeebyId(employee);
                return RedirectToAction ("Index");
            } catch (Exception) {
                return StatusCode (500);
            }
        }
    }

}