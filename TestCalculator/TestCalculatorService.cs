using CalculatorInApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculator
{
    [TestClass]
    public class TestCalculatorService
    {
        [TestMethod]
        public void Add_Input_0_and_0_Should_Return_0()
        {
            var calculatorService = new CalculatorService();
            var num1 = 0;
            var num2 = 0;
            var actual = calculatorService.Add(num1, num2);

            var expect = 0;
            
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Add_Input_1_and_1_Should_Return_2()
        {
            var calculatorService = new CalculatorService();
            var num1 = 1;
            var num2 = 1;
            var actual = calculatorService.Add(num1, num2);

            var expect = 2;
            Assert.AreEqual(expect, actual);
        }
    }
}
