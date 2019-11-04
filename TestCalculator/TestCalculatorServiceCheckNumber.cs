using System;
using System.Collections.Generic;
using System.Text;
using CalculatorInApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorServiceCheckNumber
    {
        [TestMethod]
        public void Check_Input_0_And_0_Should_Be_true()
        {
            var actual = CalculatorServiceCheckNumber(0, 0);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Check_Input_2147483647_And_1_Should_Be_false()
        {
            var actual = CalculatorServiceCheckNumber(2147483647, 1);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_Input_minus2147483648_And_minus2_Should_Be_false()
        {
            var actual = CalculatorServiceCheckNumber(-2147483648, -2);
            Assert.IsFalse(actual);
        }

        private bool CalculatorServiceCheckNumber(long num1, long num2)
        {
            var calculatorService = new CalculatorService();
            return calculatorService.CheckNumber(num1, num2);
        }
    }
}
