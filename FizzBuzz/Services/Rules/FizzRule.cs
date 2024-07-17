namespace FizzBuzz.Services.Rules
{
    public class FizzRule : IFizzBuzzRule
    {
        public bool IsMatch(int number) => number % 3 == 0;
        public string GetResult() => "Fizz";
    }

}
