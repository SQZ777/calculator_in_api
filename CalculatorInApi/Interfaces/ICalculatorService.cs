namespace CalculatorInApi.Interfaces
{
    public interface ICalculatorService
    {
        int Add(int number1, int number2);
        int Minus(int num1, int num2);
        string Divide(int number1, int number2);
    }
}