using System;
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

        public int Minus(int num1, int num2)
        {
            return num1 - num2;
        }

        public string Divide(int num1, int num2)
        {
            var result = (double)num1 / num2;
            return result.ToString("0.00");
        }

        public bool CheckNumberInDivide(int num1, int num2)
        {
            throw new System.NotImplementedException();
        }
    }
}