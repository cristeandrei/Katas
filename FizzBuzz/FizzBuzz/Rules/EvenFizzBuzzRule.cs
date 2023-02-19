namespace FizzBuzz.Rules;

public class EvenFizzBuzzRule : FizzBuzzRule
{
    private const string? EvenPrefix = "Even";

    public EvenFizzBuzzRule(FizzBuzzRule? nextRule) : base(nextRule) { }

    public override string? Next(int value)
    {
        var result = NextRule?.Next(value);

        var resultIsInt = int.TryParse(result, out _);

        if (resultIsInt && value % 2 == 0) return EvenPrefix;

        if (!resultIsInt && value % 2 == 0) return EvenPrefix + result;

        return result;
    }
}