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
        public void Divide_1_1_Should_Be_1()
        {
            var num1 = 1;
            var num2 = 1;
            var expect = new OkObjectResult(1);

            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(num1, num2)).Returns(1);
            var controller = new CalculatorController(mockCalculatorService.Object);
            var actual = controller.Divide(num1, num2) as OkObjectResult;
            Assert.AreEqual(expect.Value, actual.Value);
        }
    }
}
