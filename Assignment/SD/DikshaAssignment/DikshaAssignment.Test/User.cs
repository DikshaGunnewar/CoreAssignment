using Microsoft.VisualStudio.TestTools.UnitTesting;
using DikshaAssignment.Controllers.API;
using DikshaAssignment.Repository;
using Moq;

namespace DikshaAssignment.Test
{
    [TestClass]
    public class User
    {
        [TestMethod]
        public void TestMethod1()
        {
            private readonly Mock<IEntityBaseRepository> _repoObj;
        }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public User (){
             _repoObj = new Mock<IEntityBaseRepository>();
        }


        [TestMethod]
        public void GetEmployees_Success()
        {
            UserController controller = new UserController(_repoObj.Object);
            _repo.Setup(a => a.GetAll()).Returns(new System.Collections.Generic.List<Models.Employee>
            {
                new Models.Employee {
                      FirstName="Diksha", 
                      LastName="Gunnewar",
                      Address="Test"
                      CompanyName="SDN",
                      Designation="Fresher",
                      EmailId="dik@yopmail.com",
                      Salary="5000"
                      }
            });
            var result = (OkObjectResult)controller.GetAll();
            Assert.AreEqual(200, result.StatusCode);
            //Assert.IsNotNull(result.Value);
        }
    }
}
