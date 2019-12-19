using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecepiCRUD.Controllers;
using RecepiCRUD.Service.Interfaces;
using RecepiCRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecepiCRUD.Test
{
    [TestClass]
    public class User
    {
        private readonly Mock<IUserService> _userService;

        public User()
        {
            _userService = new Mock<IUserService>();
        }

        /// <summary>
        /// Test method for get users success.
        /// </summary>
        [TestMethod]
        public void GetUsers_Success()
        {
            ResponseVM expectedResult = new ResponseVM
            {
                Content = new UserVM
                {
                    FirstName = "Karan",
                    LastName = "Patokar",
                    Email = "karan@gmail.com",
                    Password = "1234567890",
                    PhoneNumber = "9876543210",
                    Recepi = null,
                    UserId = 1
                },
                ContentType = null,
                Id = 0,
                IsSuccess = true,
                Message = "Fetched users",
                TotalCount = null
            };
            UserController userController = new UserController(_userService.Object);
            _userService.Setup(s => s.GetAllUsers()).Returns(expectedResult);
            var response = (OkObjectResult)userController.GetAllUsers();
            var res = response.Value;
            res.Should().BeEquivalentTo(expectedResult);
            Assert.AreEqual(200, response.StatusCode);
        }

        /// <summary>
        /// Test method for no users found.
        /// </summary>
        [TestMethod]
        public void GetUsers_NotFound()
        {
            UserController userController = new UserController(_userService.Object);
            _userService.Setup(s => s.GetAllUsers()).Returns(new ResponseVM());
            var response = (NotFoundResult)userController.GetAllUsers();
            Assert.AreEqual(404, response.StatusCode);
        }

        /// <summary>
        /// Test method for get users exception.
        /// </summary>
        [TestMethod]
        public void GetUsers_Exception()
        {
            UserController userController = new UserController(_userService.Object);
            _userService.Setup(s => s.GetAllUsers()).Throws(new System.Exception());
            var response = (StatusCodeResult)userController.GetAllUsers();
            Assert.AreEqual(500, response.StatusCode);
        }
    }
}
