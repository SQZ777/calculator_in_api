using System;
using System.Collections.Generic;
using System.Text;
using CalculatorInApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorServiceMinus
    {
        [TestMethod]
        public void Minus_1_and_1_Should_Be_0()
        {
            var num1 = 1;
            var num2 = 1;
            var calculatorService = new CalculatorService();
            var actual = calculatorService.Minus(num1, num2);
            var expect = 0;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Minus_m1_and_1_Should_Be_m2()
        {
            var num1 = -1;
            var num2 = 1;
            var calculatorService = new CalculatorService();
            var actual = calculatorService.Minus(num1, num2);
            var expect = -2;
            Assert.AreEqual(expect, actual);
        }
    }
}