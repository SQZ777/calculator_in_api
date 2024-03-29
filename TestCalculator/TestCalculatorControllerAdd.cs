﻿using System;
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
            var expect = new OkObjectResult(0);
            var actual = AddWhenExpectIsOk(0, 0, 0);
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Add_2147483647_and_1_Should_be_InputIsIllegally_and_StatusCode_400()
        {
            var actual = AddWhenExpectIsBadRequest(2147483647, 1);
            var expect = new BadRequestObjectResult("InputIsIllegally");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        [TestMethod]
        public void Add_minus2147483648_and_minus1_Should_be_InputIsIllegally_and_StatusCode_400()
        {
            var actual = AddWhenExpectIsBadRequest(-2147483648, -1);
            var expect = new BadRequestObjectResult("InputIsIllegally");
            Assert.AreEqual(expect.Value, actual.Value);
        }

        private BadRequestObjectResult AddWhenExpectIsBadRequest(int num1, int num2)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(false);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);
            var actual = calculatorController.Add(num1, num2) as BadRequestObjectResult;
            return actual;
        }

        private OkObjectResult AddWhenExpectIsOk(int num1, int num2, int mockAddReturn)
        {
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.CheckNumber(num1, num2)).Returns(true);
            mockCalculatorService.Setup(x => x.Add(num1, num2)).Returns(mockAddReturn);
            var calculatorController = new CalculatorController(mockCalculatorService.Object);
            var actual = calculatorController.Add(num1, num2) as OkObjectResult;
            return actual;
        }

    }
}
