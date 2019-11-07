using System;
using System.Collections.Generic;
using System.Text;
using CalculatorInApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorServiceCheckNumberInDivide
    {
        [TestMethod]
        public void CheckNumberInDivide_1_1_Should_Be_true()
        {
            var calculatorService = new CalculatorService();
            var actual = calculatorService.CheckNumberInDivide(1, 1);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckNumberInDivide_1_0_Should_Be_false()
        {
            var calculatorService = new CalculatorService();
            var actual = calculatorService.CheckNumberInDivide(1, 0);
            Assert.IsFalse(actual);
        }
    }
}
