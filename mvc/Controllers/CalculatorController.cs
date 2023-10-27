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
        public IActionResult Calculate(Calculator calculator, string reset)
        {
            if (!string.IsNullOrEmpty(reset) && reset.Equals("reset"))
            {
                
                calculator.Answer = string.Empty;
                return View("Index", calculator);
            }

            try
            {
                var operationType = GetCalculatorOperationType(calculator.Action);

                // manage custom exception here
                if (operationType.Equals(CalculatorOperation.Divide) && calculator.Operator2 == 0)
                {
                    calculator.Answer = "0";
                    return View("Index", calculator);
                }
               
                calculator.Answer = CalculatorHelper.Calculate(calculator.Operator1, calculator.Operator2, operationType).ToString();
               
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