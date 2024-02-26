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

        // +
        [HttpGet("addition/{firstNumber}/{secNumber}")]
        public IActionResult Get(string firstNumber, string secNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secNumber))
            {
                var addition = ConvertToDecimal(firstNumber) + ConvertToDecimal(secNumber);

                return Ok(addition.ToString());
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

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalNumber;

            if (decimal.TryParse(strNumber, out decimalNumber))
            {
                return decimalNumber;
            }

            return 0;
        }
    }
}
