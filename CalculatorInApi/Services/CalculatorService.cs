using CalculatorInApi.Interfaces;

namespace CalculatorInApi.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public bool CheckNumber(long num1, long num2)
        {
            return true;
            throw new System.NotImplementedException();
        }
    }
}