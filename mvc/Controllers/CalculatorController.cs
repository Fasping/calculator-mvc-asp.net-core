using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Helper;
using System;

namespace mvc.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(Calculator calculator)
        {
            try
            {
                calculator.Answer = CalculatorHelper.Calculate(calculator.Operator1, calculator.Operator2,
                    GetCalculatorOperationType(calculator.Action)).ToString();
            }
            catch (Exception)
            {
                calculator.Answer = "Error occurred during calculation.";
            }

            return View("Index", calculator);
        }

        private CalculatorOperation GetCalculatorOperationType(string action)
        {
            return action switch
            {
                "+" => CalculatorOperation.Add,
                "-" => CalculatorOperation.Subtract,
                "*" => CalculatorOperation.Multiply,
                "/" => CalculatorOperation.Divide,
                _ => throw new ArgumentException("Invalid operator."),
            };
        }
    }
}