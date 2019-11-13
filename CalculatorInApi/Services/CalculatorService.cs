using System;
using CalculatorInApi.Interfaces;

namespace CalculatorInApi.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int number1, int number2)
        {
            int result = 0;
            result = checked(number1 + number2);
            return result;
        }

        public int Minus(int number1, int number2)
        {
            int result = 0;
            result = checked(number1 - number2);
            return result;
        }

        public string Divide(int number1, int number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException();
            }

            var result = (double) number1 / number2;
            return result.ToString("0.00");
        }
    }
}