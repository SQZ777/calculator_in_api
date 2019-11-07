using System;
using System.Collections.Generic;
using System.Text;
using CalculatorInApi.Controllers;
using CalculatorInApi.Interfaces;
using CalculatorInApi.Services;
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
            var actual = calculatorController.Minus(1, 1);
            var expect = 0;
            Assert.AreEqual(expect, actual);

        }
    }
}
