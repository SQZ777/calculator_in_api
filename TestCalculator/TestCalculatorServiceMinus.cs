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
            TestMinus(1,1,0);
        }

        [TestMethod]
        public void Minus_m1_and_1_Should_Be_m2()
        {
            TestMinus(-1, 1, -2);
        }

        private void TestMinus(int num1, int num2, int expect)
        {
            var calculatorService = new CalculatorService();
            var actual = calculatorService.Minus(num1, num2);
            Assert.AreEqual(expect, actual);
        }
    }
}