using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public async Task<IActionResult> GetFizzBuzzResults([FromBody] IEnumerable<string> values)
        {
            var results = await _fizzBuzzService.GetFizzBuzzResults(values);
            return Ok(new { Results = results.InputData, Operations = results.Results });
            
        }
    }

}
