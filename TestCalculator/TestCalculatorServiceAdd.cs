using System.ComponentModel;
using CalculatorInApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorServiceAdd
    {
        [TestMethod]
        public void Add_Input_0_and_0_Should_Return_0()
        {

            var actual = CalculatorServiceAdd(0, 0);
            var expect = 0;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Add_Input_1_and_1_Should_Return_2()
        {
            var actual = CalculatorServiceAdd(1, 1);
            var expect = 2;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Add_Input_minus1_and_minus1_Return_minus2()
        {
            var actual = CalculatorServiceAdd(-1, -1);
            var expect = -2;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Add_Input_minus1_and_0_Return_minus1()
        {
            var actual = CalculatorServiceAdd(-1, 0);
            var expect = -1;
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Add_Input_0_and_minus1_Return_minus1()
        {
            var actual = CalculatorServiceAdd(0, -1);
            var expect = -1;
            Assert.AreEqual(expect, actual);
        }

        private int CalculatorServiceAdd(int num1, int num2)
        {
            var calculatorService = new CalculatorService();
            var actual = calculatorService.Add(num1, num2);
            return actual;
        }
    }
}
