using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorInApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorInApi.Controllers
{
    public class CalculatorController : Controller
    {
        private ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        public IActionResult Add(int num1, int num2)
        {

            if (_calculatorService.CheckNumber(num1, num2))
            {
                return Ok(_calculatorService.Add(num1, num2));
            }
            throw new NotImplementedException();
        }
    }
}