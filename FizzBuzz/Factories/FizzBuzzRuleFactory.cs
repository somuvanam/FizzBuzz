using FizzBuzz.Services.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzz.Factories
{
    public class FizzBuzzRuleFactory : IFizzBuzzRuleFactory
    {
        //private readonly IServiceProvider _serviceProvider;

        //public FizzBuzzRuleFactory(IServiceProvider serviceProvider)
        //{
        //    _serviceProvider = serviceProvider;
        //}
        private readonly List<IFizzBuzzRule> _rules;

        public FizzBuzzRuleFactory()
        {
            _rules = new List<IFizzBuzzRule>
            {
                new FizzBuzzRule(),
                new FizzRule(),
                new BuzzRule()
            };
        }

        public IFizzBuzzRule CreateRule(int number)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(number))
                {
                    return rule;
                }
            }
            return null;
        }
    }

}
