using FizzBuzz;

using System.Text.RegularExpressions;

namespace FizzBuzzTests;

public class FizzBuzzTests
{
    [Test]
    public void FizzBuzzApprovalTest()
    {
        var fizzBuzzGenerator = new FizzBuzzGenerator();

        var result = fizzBuzzGenerator.Get(36).ToList();

        Assert.That(result,
            Is.EquivalentTo(new[] {
                "1", "Prime", "Prime", "Even", "Prime", "EvenFizz", "Prime", "Even", "Fizz", "EvenBuzz", "Prime", "EvenFizz", "Prime", "Even",
                "FizzBuzz", "Even", "Prime", "EvenFizz", "Prime", "EvenBuzz", "Fizz", "Even", "Prime", "EvenFizz", "Buzz", "Even", "Fizz", "Even", "Prime",
                "EvenFizzBuzz", "Prime", "Even", "Fizz", "Even", "Buzz", "EvenFizz"
            }));
    }

    [Test]
    public void Get_ShouldGenerateOnlyValidOutputs()
    {
        var fizzBuzzGenerator = new FizzBuzzGenerator();

        var result = fizzBuzzGenerator.Get(1000);

        Assert.That(result, Is.All.Match("^(?:Even)?(Prime|Even|FizzBuzz|Fizz|Buzz|[0-9]+)$"));
    }

    [Test]
    public void Get_AllNonNumericOutputsShouldMatchTheirOrdinalPosition()
    {
        var fizzBuzzGenerator = new FizzBuzzGenerator();

        var result = fizzBuzzGenerator.Get(10000);

        var sequenceWithOrdinaryPosition = result.Select((e, i) => (e, i + 1));

        Assert.That(sequenceWithOrdinaryPosition, Is.All.Matches<(string Value, int Position)>(e => e.Value == e.Position.ToString()
                                                                                                    || Regex.IsMatch(e.Value,
                                                                                                        "^(?:Even)?(Prime|Even|FizzBuzz|Fizz|Buzz)$")));
    }
}