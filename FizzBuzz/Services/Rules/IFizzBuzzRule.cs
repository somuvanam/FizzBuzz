namespace FizzBuzz.Services.Rules
{
    //public interface IFizzBuzzService
    //{
    //    IEnumerable<string> GetFizzBuzzResults(IEnumerable<string> values, out List<string> operations);
    //}
    public interface IFizzBuzzRule
    {
        bool IsMatch(int number);
        string GetResult();
    }

}
