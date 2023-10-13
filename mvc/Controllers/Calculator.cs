using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers { 


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

  
    }
}