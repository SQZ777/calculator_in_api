using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorInApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorInApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        [HttpGet("Add")]
        public IActionResult Add([FromQuery]int num1, int num2)
        {
            if (_calculatorService.CheckNumber(num1, num2))
            {
                return Ok(_calculatorService.Add(num1, num2));
            }
            return BadRequest("InputIsIllegally");
        }

        [HttpGet("Minus")]
        public IActionResult Minus([FromQuery]int num1, int num2)
        {
            if (_calculatorService.CheckNumber(num1, num2))
            {
                return Ok(_calculatorService.Minus(num1, num2));
            }
            return BadRequest("InputIsIllegally");
        }

        public IActionResult Divide(int num1, int num2)
        {
            if (_calculatorService.CheckNumber(num1, num2) && _calculatorService.CheckNumberInDivide(num1, num2))
            {
                return Ok(_calculatorService.Divide(num1, num2));
            }
            return BadRequest("InputIsIllegally");
        }
    }
}