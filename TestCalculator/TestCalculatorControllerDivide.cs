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
            var num1 = 1;
            var num2 = 1;
            var expect = new OkObjectResult("1.00");

            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(num1, num2)).Returns("1.00");
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num1)).Returns(true);
            var controller = new CalculatorController(mockCalculatorService.Object);
            var actual = controller.Divide(num1, num2) as OkObjectResult;
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Divide_1_3_Should_Be_0_33()
        {
            var num1 = 1;
            var num2 = 3;
            var expect = new OkObjectResult("0.33");

            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(num1, num2)).Returns("0.33");
            mockCalculatorService.Setup(x => x.CheckNumberInDivide(num1, num2)).Returns(true);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);
            var actual = calculatorController.Divide(num1, num2) as OkObjectResult;
            Assert.AreEqual(expect.Value, actual.Value);
        }
    }
}
