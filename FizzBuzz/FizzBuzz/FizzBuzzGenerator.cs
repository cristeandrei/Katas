
namespace FizzBuzz;

public class FizzBuzzGenerator {
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";
    private const string Even = "Even";
    private const string Prime = "Prime";

    public IEnumerable<string> Get(int count) {
        return Enumerable.Range(1, count)
            .Select(FizzBuzzText);
    }

    private string FizzBuzzText(int value) {
        if (value.IsPrime()) {
            return Prime;
        }

        if (value % 3 == 0 && value % 5 == 0) {
            return EvenPrefix(value, Fizz + Buzz);
        }

        if (value % 3 == 0) {
            return EvenPrefix(value, Fizz);
        }

        if (value % 5 == 0) {
            return EvenPrefix(value, Buzz);
        }

        return CheckForEvenOrText(value);
    }

    public string EvenPrefix(int value, string text) {
        if (value % 2 == 0) return Even + text;

        return text;
    }

    public string CheckForEvenOrText(int value) {
        if (value % 2 == 0) return Even;

        return value.ToString();
    }
}