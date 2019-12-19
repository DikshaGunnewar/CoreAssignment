using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecepiCRUD.Controllers;
using RecepiCRUD.Service.Interfaces;
using RecepiCRUD.ViewModel;

namespace RecepiCRUD.Test
{
    [TestClass]
    public class Recepi
    {
        private readonly Mock<IRecepiService> _recepiService;

        public Recepi()
        {
            _recepiService = new Mock<IRecepiService>();
        }

        /// <summary>
        /// Test method for get recepi success
        /// </summary>
        [TestMethod]
        public void GetRecepi_Success()
        {
            ResponseVM expectedResult = new ResponseVM
            {
                Content = new RecepiVM
                {
                    RecepiId = 1,
                    RecepiName = "Karan",
                    RecepiDesc = "Something",
                    RecepiImage = null,
                    UserId = 1
                },
                IsSuccess = true,
                Message = "Successful",
                TotalCount = null,
                ContentType = null,
                Id = 0
            };
            RecepiController recepiController = new RecepiController(_recepiService.Object);
            _recepiService.Setup(s => s.GetRecepi()).Returns(expectedResult);
            var response = (OkObjectResult)recepiController.GetRecepies();
            var res = response.Value;
            res.Should().BeEquivalentTo(expectedResult);
            Assert.AreEqual(200, response.StatusCode);
        }

        /// <summary>
        /// Test method for no recepi found.
        /// </summary>
        [TestMethod]
        public void GetRecepi_NotFound()
        {
            RecepiController recepiController = new RecepiController(_recepiService.Object);
            _recepiService.Setup(s => s.GetRecepi()).Returns(new ResponseVM());
            var response = (NotFoundResult)recepiController.GetRecepies();
            Assert.AreEqual(404, response.StatusCode);
        }

        /// <summary>
        /// Test method for get recepi exception.
        /// </summary>
        [TestMethod]
        public void GetRecepi_Exception()
        {
            RecepiController recepiController = new RecepiController(_recepiService.Object);
            _recepiService.Setup(s => s.GetRecepi()).Throws(new System.Exception());
            var response = (StatusCodeResult)recepiController.GetRecepies();
            Assert.AreEqual(500, response.StatusCode);
        }
    }
}
