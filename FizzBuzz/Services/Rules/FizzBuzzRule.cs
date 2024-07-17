namespace FizzBuzz.Services.Rules
{
    public class FizzBuzzRule : IFizzBuzzRule
    {
        public bool IsMatch(int number) => number % 3 == 0 && number % 5 == 0;
        public string GetResult() => "FizzBuzz";
    }
    
}
