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
            var num1 = 0;
            var num2 = 0;
            var calculatorService = new CalculatorService();
            var actual = calculatorService.CheckNumber(num1, num2);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Check_Input_2147483647_And_1_Should_Be_false()
        {
            var num1 = 2147483647;
            var num2 = 1;
            var calculatorService = new CalculatorService();
            var actual = calculatorService.CheckNumber(num1, num2);
            Assert.IsFalse(actual);
        }
    }
}
