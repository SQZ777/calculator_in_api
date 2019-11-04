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
    public class TestCalculatorControllerAdd
    {
        [TestMethod]
        public void Add_0_and_0_Should_be_0()
        {
            var num1 = 0;
            var num2 = 0;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(true);
            mockCalculatorService.Setup(x => x.Add(num1, num2)).Returns(0);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);

            var actual = calculatorController.Add(num1, num2) as OkObjectResult;
            var expect = new OkObjectResult(0);

            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Add_2147483647_and_1_Should_be_InputIsIllegally_and_StatusCode_400()
        {
            var num1 = 2147483647;
            var num2 = 1;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(false);
            mockCalculatorService.Setup(x => x.Add(num1, num2)).Returns(0);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);

            var actual = calculatorController.Add(num1, num2) as BadRequestObjectResult;
            var expect = new BadRequestObjectResult("InputIsIllegally");

            Assert.AreEqual(expect.Value, actual.Value);
        }
    }
}
