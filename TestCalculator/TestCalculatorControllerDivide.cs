using System;
using System.Collections.Generic;
using System.Text;
using CalculatorInApi.Controllers;
using CalculatorInApi.Interfaces;
using CalculatorInApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorControllerDivide
    {
        [TestMethod]
        public void Divide_1_1_Should_Be_1_00()
        {
            var expect = new OkObjectResult("1.00");
            var actual = DivideWhenExpectIsOk(1, 1, "1.00");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Divide_1_3_Should_Be_0_33()
        {
            var expect = new OkObjectResult("0.33");
            var actual = DivideWhenExpectIsOk(1, 3, "0.33");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Divide_1_0_Should_Be_BadRequest_InputIsIllegally()
        {
            var expect = new BadRequestObjectResult("InputIsIllegally");
            var actual = DivideWhenExpectIsBadRequest(1, 0);
            Assert.AreEqual(expect.GetType(), actual.GetType());
        }

        private BadRequestObjectResult DivideWhenExpectIsBadRequest(int num1, int num2)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(num1, num2)).Throws(new DivideByZeroException());

            var controller = new CalculatorController(mockCalculatorService.Object);
            var actual = controller.Divide(num1, num2) as BadRequestObjectResult;
            return actual;
        }

        private OkObjectResult DivideWhenExpectIsOk(int num1, int num2, string mockDivideReturn)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(num1, num2)).Returns(mockDivideReturn);
            var controller = new CalculatorController(mockCalculatorService.Object);
            var actual = controller.Divide(num1, num2) as OkObjectResult;
            return actual;
        }
    }
}