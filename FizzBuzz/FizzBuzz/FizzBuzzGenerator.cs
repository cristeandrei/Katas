using FizzBuzz.Rules;

namespace FizzBuzz;

public class FizzBuzzGenerator
{
    private readonly FizzBuzzRule _fizzBuzzRule;

    public FizzBuzzGenerator() => _fizzBuzzRule = new PrimeFizzBuzzRule(new EvenFizzBuzzRule(new ThreeAndFiveFizzBuzzRule()));

    public IEnumerable<string> Get(int count)
    {
        return Enumerable.Range(1, count)
            .Select(_fizzBuzzRule.Next)
            .Where(e => e != null)
            .Cast<string>();
    }
}