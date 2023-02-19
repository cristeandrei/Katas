namespace FizzBuzz.Rules;

public abstract class FizzBuzzRule {
    protected readonly FizzBuzzRule? NextRule;

    protected FizzBuzzRule(FizzBuzzRule? nextRule) {
        NextRule = nextRule;
    }

    public abstract string? Next(int value);
}