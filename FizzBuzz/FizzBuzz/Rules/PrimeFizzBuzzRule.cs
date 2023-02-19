namespace FizzBuzz.Rules;

public class PrimeFizzBuzzRule : FizzBuzzRule
{
    private const string? Prime = "Prime";

    public PrimeFizzBuzzRule(FizzBuzzRule? nextRule) : base(nextRule) { }

    public override string? Next(int value) => value.IsPrime() ? Prime : NextRule?.Next(value);
}