using System.Diagnostics;
using CalculatorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{

    public class CalculatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CalculatorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Calculate(Calculator objCalculator)
        {
            if ("+".Equals(objCalculator.Action))
            {
                objCalculator.Answer = objCalculator.Operator1 + objCalculator.Operator2;
            }

            return View("index",objCalculator);
        }


    }
}