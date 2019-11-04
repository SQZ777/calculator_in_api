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
            if (num1 + num2 > 2147483647 || num1 + num2 < -2147483648)
            {
                return false;
            }
            return true;
        }
    }
}