using Microsoft.AspNetCore.Mvc;
using OpenTrade.Logic.Services;

namespace OpenTrade.AspNetCore.Controllers
{
    [Route("api/fibonacci")]
    public class FibonacciController : Controller
    {
        private readonly IFibonacciHandler _fibonacciHandler;

        public FibonacciController(IFibonacciHandler fibonacciHandler)
        {
            _fibonacciHandler = fibonacciHandler;
        }

        [HttpGet("getprevious")]
        public IActionResult GetPrevious([FromQuery] int n)
        {
            try
            {
                var result = _fibonacciHandler.GetPreviousFibonacci(n);
                return Ok(
                    $"f(n-1): {result.prev1}; f(n-2): {result.prev2}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
