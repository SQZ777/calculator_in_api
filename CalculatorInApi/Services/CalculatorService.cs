using CalculatorInApi.Interfaces;

namespace CalculatorInApi.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}