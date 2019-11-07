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
            var num1 = 1;
            var num2 = 1;
            SetCalculatorController(num1, num2, false);
            var calculatorController = SetCalculatorController(num1, num2, true);
            var actual = calculatorController.Minus(num1, num2) as OkObjectResult;
            var expect = new OkObjectResult(0);
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Minus_m2147483648_and_1_Should_Be_BadRequest_InputIsIllegally()
        {
            var num1 = -2147483648;
            var num2 = 1;
            SetCalculatorController(num1, num2, false);
            var calculatorController = SetCalculatorController(num1, num2, false);
            var actual = calculatorController.Minus(num1, num2) as BadRequestObjectResult;
            var expect = new BadRequestObjectResult("InputIsIllegally");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        private CalculatorController SetCalculatorController(int num1, int num2, bool checkNumberShouldReturn)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(checkNumberShouldReturn);
            mockCalculatorService.Setup(x => x.Add(num1, num2)).Returns(0);
            return new CalculatorController(mockCalculatorService.Object);
        }
    }
}
