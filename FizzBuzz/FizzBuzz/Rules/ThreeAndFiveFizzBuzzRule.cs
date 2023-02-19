namespace FizzBuzz.Rules;

public class ThreeAndFiveFizzBuzzRule : FizzBuzzRule
{
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";

    public ThreeAndFiveFizzBuzzRule(FizzBuzzRule? nextRule = null) : base(nextRule) { }

    public override string? Next(int value)
    {
        if (value % 3 == 0 && value % 5 == 0) return Fizz + Buzz;

        if (value % 3 == 0) return Fizz;

        if (value % 5 == 0) return Buzz;

        return value.ToString();
    }
}