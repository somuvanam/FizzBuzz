namespace FizzBuzz.Services.Rules
{
    public class BuzzRule : IFizzBuzzRule
    {
        public bool IsMatch(int number) => number % 5 == 0;
        public string GetResult() => "Buzz";
    }

}
