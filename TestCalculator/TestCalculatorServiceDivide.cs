using System;
using System.Collections.Generic;
using System.Text;
using CalculatorInApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorServiceDivide
    {
        [TestMethod]
        public void Divide_1_1_Should_Be_1_00()
        {
            var calculatorService = new CalculatorService();
            var actual = calculatorService.Divide(1, 1);
            var expect = "1.00";
            Assert.AreEqual(expect, actual);
        }
    }
}
