using Microsoft.AspNetCore.Mvc;

namespace RESTWithNET8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("add/{firstNumber}/{secondNumber}")]
        public IActionResult Add(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var addition = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(addition.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult Divide(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(division.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(mean.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("squareroot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt(ConvertToDouble(number));

                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo, out number); 

            return isNumber;
        }

        private decimal ConvertToDecimal(string stringNumber)
        {
            decimal decimalNumber;

            if (decimal.TryParse(stringNumber, out decimalNumber))
            {
                return decimalNumber;
            }

            return 0;
        }

        private double ConvertToDouble(string stringNumber)
        {
            double doubleNumber;

            if (double.TryParse(stringNumber, out doubleNumber))
            {
                return doubleNumber;
            }

            return 0;
        }
    }
}
