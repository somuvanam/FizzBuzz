using FizzBuzz.Factories;
using Microsoft.AspNetCore.Components.Forms;

namespace FizzBuzz.Services
{
    public class FizzBuzzResult
    {
        public IEnumerable<string> InputData { get; set; }
        public List<string> Results { get; set; }
    }
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IFizzBuzzRuleFactory _ruleFactory;

        public FizzBuzzService(IFizzBuzzRuleFactory ruleFactory)
        {
            _ruleFactory = ruleFactory;
        }

        public async Task<FizzBuzzResult> GetFizzBuzzResults(IEnumerable<string> values)
        {
            var inputdataList = new List<string>();
            var resultsList = new List<string>();

            foreach (var value in values)
            {
                inputdataList.Add(value);
                if (int.TryParse(value, out int number))
                {
                    var rule = _ruleFactory.CreateRule(number);
                    var result = rule != null ? rule.GetResult() : $"Divided {number} by 3\nDivided {number} by 5";
                    resultsList.Add(result);
                }
                else
                {
                    resultsList.Add("Invalid item");
                }
            }

            return new FizzBuzzResult { InputData = inputdataList, Results = resultsList };
        }
    }


}
