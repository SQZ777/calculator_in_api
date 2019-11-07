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
    public class TestCalculatorControllerMinus
    {
        [TestMethod]
        public void Minus_1_and_1_Should_Be_0()
        {
            var mockService = new Mock<ICalculatorService>();
            mockService.Setup(x => x.Minus(1, 1)).Returns(0);
            var calculatorController = new CalculatorController(mockService.Object);
            var actual = calculatorController.Minus(1, 1) as OkObjectResult;
            var expect = new OkObjectResult(0);
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Minus_m2147483648_and_1_Should_Be_BadRequest_InputIsIllegally()
        {
            var mockService = new Mock<ICalculatorService>();
            mockService.Setup(x => x.CheckNumber(-2147483648, 1)).Returns(false);
            var calculatorController = new CalculatorController(mockService.Object);
            var actual = calculatorController.Minus(-214783648, 1) as BadRequestObjectResult;
            var expect = new BadRequestObjectResult("InputIsIllegally");
            Assert.AreEqual(expect.Value, actual.Value);

        }
    }
}
