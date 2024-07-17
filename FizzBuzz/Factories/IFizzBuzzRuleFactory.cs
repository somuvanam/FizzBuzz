using FizzBuzz.Services.Rules;

namespace FizzBuzz.Factories
{
    public interface IFizzBuzzRuleFactory
    {
        IFizzBuzzRule CreateRule(int number);
    }

}
