using System;

namespace mvc.Helper
{
    public enum CalculatorOperation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public static class CalculatorHelper
    {
        public static double Calculate(double op1, double op2, CalculatorOperation operation)
        {
            return operation switch
            {
                CalculatorOperation.Add => op1 + op2,
                CalculatorOperation.Subtract => op1 - op2,
                CalculatorOperation.Multiply => op1 * op2,
                CalculatorOperation.Divide => op1 / op2,
                _ => throw new ArgumentException("Invalid operation."),
            };
        }
    }
}
