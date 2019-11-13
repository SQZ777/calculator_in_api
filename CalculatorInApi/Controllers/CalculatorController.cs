using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorInApi.Interfaces;
using CalculatorInApi.Services;
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
        public IActionResult Add([FromQuery] int num1, int num2)
        {
            try
            {
                var result = _calculatorService.Add(num1, num2);
                return Ok(result);
            }
            catch (OverflowException exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet("Minus")]
        public IActionResult Minus([FromQuery] int num1, int num2)
        {
            try
            {
                var result = _calculatorService.Minus(num1, num2);
                return Ok(result);
            }
            catch (OverflowException exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet("Divide")]
        public IActionResult Divide(int num1, int num2)
        {
            try
            {
                var result = _calculatorService.Divide(num1, num2);
                return Ok(result);
            }
            catch (DivideByZeroException exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    }
}