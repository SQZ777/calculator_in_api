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
            var actual = TestDivideWhenExpectIsOk(1, 1, "1.00");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Divide_1_3_Should_Be_0_33()
        {
            var expect = new OkObjectResult("0.33");
            var actual = TestDivideWhenExpectIsOk(1, 3, "0.33");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        private OkObjectResult TestDivideWhenExpectIsOk(int num1, int num2, string mockDivideReturn)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(num1, num2)).Returns(mockDivideReturn);
            mockCalculatorService.Setup(x => x.CheckNumberInDivide(num1, num2)).Returns(true);
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(true);
            var controller = new CalculatorController(mockCalculatorService.Object);
            var actual = controller.Divide(num1, num2) as OkObjectResult;
            return actual;
        }
    }
}
