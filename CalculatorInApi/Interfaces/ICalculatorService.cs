using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorInApi.Interfaces
{
    public interface ICalculatorService
    {
        int Add(int number1, int number2);

        bool CheckNumber(long num1, long num2);
    }
}
