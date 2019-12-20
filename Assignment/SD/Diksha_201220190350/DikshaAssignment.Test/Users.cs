using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DikshaAssignment.Controllers.API;
using DikshaAssignment.Repository;
using DikshaAssignment.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using System.Threading.Tasks;

namespace DikshaAssignment.Users
{
    [TestClass]
    public class Users
    {
        
        private readonly Mock<IEntityBaseRepository<Employee>> _repoObj;

        /// <summary>
        /// Default Constructor
        /// </summary>

        public Users (){
             _repoObj = new Mock<IEntityBaseRepository<Employee>>();
        }

      #region Get all employee test cases
        [TestMethod]
        public void GetAllEmployees_Success()
        {
            List<Employee> expectedResult = new List<Employee>()
             { 
                  new Employee {
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
                },
                new Employee {
                      EmployeeId=2,
                      FirstName="Lisa", 
                      LastName="William",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="Lisa@yopmail.com",
                      Salary=5000
                }    
            };

            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.GetAll()).Returns(expectedResult.AsQueryable());
            var result = (OkObjectResult)controller.GetAll();
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
             var res = result.Value;
             res.Should().BeEquivalentTo(expectedResult.AsQueryable());
          }

        [TestMethod]
        public void GetAllEmployees_NoRecords()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.GetAll()).Returns(new System.Collections.Generic.List<Models.Employee>().AsQueryable());
            var result = (NotFoundResult)controller.GetAll();
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void GetALLEmployees_Exception()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.GetAll()).Throws(new System.Exception());
            var result = (StatusCodeResult)controller.GetAll();
            Assert.AreEqual(500, result.StatusCode);
        }

#endregion


      #region Get Employee by Id test cases

        [TestMethod]
        public void GetEmployeesbyId_Success()
        {
            Employee expectedResult = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
             };

            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(1)).Returns(expectedResult);
            var result = (OkObjectResult)controller.GetstringById(1);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
            var res = result.Value;
            res.Should().BeEquivalentTo(expectedResult);
          }


        [TestMethod]
        public void GetEmployeesbyId_NoRecords()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(1));
            var result = (NotFoundResult)controller.GetstringById(1);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void GetEmployeesby_Exception()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(1)).Throws(new System.Exception());
            var result = (StatusCodeResult)controller.GetstringById(1);
            Assert.AreEqual(500, result.StatusCode);
        }
      
#endregion
      
      
      #region Add empolyee test cases
        [TestMethod]
        public async Task AddEmployees_Success()
        {
             Employee inputObject = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
             };

            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Create(inputObject));
            var res = await controller.AddEmployee(inputObject);
            var result = (OkObjectResult)res;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
           
          }

        [TestMethod]
        public async Task AddEmployees_BadRequest()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Create(null));
            var res = await controller.AddEmployee(null);
            var result = (BadRequestObjectResult)res;
            Assert.AreEqual(400, result.StatusCode);
        
          }


        [TestMethod]
        public async Task AddEmployees_Exception()
        {
            Employee inputObject = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
             };
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Create(inputObject)).Throws(new System.Exception());
            var res = await controller.AddEmployee(inputObject);
            var result = (StatusCodeResult)res;
            Assert.AreEqual(500, result.StatusCode);
            
        }
    #endregion


     #region Update employee test cases
       [TestMethod]
        public async Task EditEmployees_Success()
        {
             Employee inputObject = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5001
             };

            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Update(inputObject));
            var res = await controller.UpdateEmployee(1, inputObject);
            var result = (OkObjectResult)res;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
           
          }

        [TestMethod]
        public async Task EditEmployees_BadRequest()
        {
            Employee inputObject = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5001
             };
            UserController controller = new UserController(_repoObj.Object);
            
            var res = await controller.UpdateEmployee(2, inputObject); 
             _repoObj.Setup(a => a.Update(inputObject));
            var result = (BadRequestResult)res;
            Assert.AreEqual(400, result.StatusCode);
        
          }

        [TestMethod]
        public async Task EditEmployees_NotFound()
        {
            Employee inputObject = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
             };
            UserController controller = new UserController(_repoObj.Object);
            
            _repoObj.Setup(a => a.Update(inputObject)).Throws(new System.Exception());
            _repoObj.Setup(a => a.Get(null));
            var res = await controller.UpdateEmployee(1,inputObject);
            var result = (NotFoundResult)res;
            Assert.AreEqual(404, result.StatusCode);
            
        }

        [TestMethod]
        public async Task EditEmployees_Exception()
        {
            Employee empOutputData = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
             };
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(1)).Returns(empOutputData);
            _repoObj.Setup(a => a.Update(empOutputData)).Throws(new System.Exception());
            var res = await controller.UpdateEmployee(1,empOutputData);
            var result = (StatusCodeResult)res;
            Assert.AreEqual(500, result.StatusCode);
            
        }
    #endregion


    #region Employee delete test cases
      [TestMethod]
        public void DeleteEmployeesbyId_Success()
        {
            Employee expectedResult = new Employee()
             { 
                      EmployeeId=1,
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test",
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary=5000
             };

            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(1)).Returns(expectedResult);
            _repoObj.Setup(a => a.Delete(expectedResult));
            var result = (OkObjectResult)controller.DeleteEmployeeById(1);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value);
          }


        [TestMethod]
        public void DeleteEmployeesbyId_NoRecords()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(1));
             _repoObj.Setup(a => a.Delete(null));
            var result = (NotFoundResult)controller.DeleteEmployeeById(1);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DeleteEmployeesbyId_BadRequest()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repoObj.Setup(a => a.Get(null));
             _repoObj.Setup(a => a.Delete(null));
            var result = (NotFoundResult)controller.DeleteEmployeeById(1);
            Assert.AreEqual(404, result.StatusCode);
        }

        

    #endregion
      
  
    }
}
