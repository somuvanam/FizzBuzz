namespace FizzBuzz.Services
{
    public interface IFizzBuzzService
    {
        Task<FizzBuzzResult> GetFizzBuzzResults(IEnumerable<string> values);
    }
}
