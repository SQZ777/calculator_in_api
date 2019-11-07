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
            var actual = MinusWhenExpectIsOk(1, 1, 0);
            var expect = new OkObjectResult(0);
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Minus_m1_and_m1_Should_Be_0()
        {
            var actual = MinusWhenExpectIsOk(-1, -1, 0);
            var expect = new OkObjectResult(0);
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Minus_m1_and_1_Should_Be_m2()
        {
            var actual = MinusWhenExpectIsOk(-1, 1, -2);
            var expect = new OkObjectResult(-2);
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Minus_m2147483648_and_1_Should_Be_BadRequest_InputIsIllegally()
        {
            var actual = MinusWhenExpectIsBadRequest(-2147483648, 1);
            var expect = new BadRequestObjectResult("InputIsIllegally");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        private OkObjectResult MinusWhenExpectIsOk(int num1, int num2, int mockAddReturn)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(true);
            mockCalculatorService.Setup(x => x.Minus(num1, num2)).Returns(mockAddReturn);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);
            var actual = calculatorController.Minus(num1, num2) as OkObjectResult;
            return actual;
        }

        private BadRequestObjectResult MinusWhenExpectIsBadRequest(int num1, int num2)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(false);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);
            var actual = calculatorController.Minus(num1, num2) as BadRequestObjectResult;
            return actual;
        }
    }
}
