[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace MarsRoverTest;
[TestClass()]
public class NavigationInterpreterShould
{
    private Location _current;
    public NavigationInterpreterShould()
    {
        _current = new Location(0, 0, Direction.North);
    }

    [DataTestMethod()]
    [DynamicData(nameof(DetermineNextLocationData))]
    public void DetermineNextLocation(char command, Location expected)
    {
        var interpreter = new NavigationInterpreter();

        var interpretedLocation = interpreter.DetermineNextLocation(command, _current);

        Assert.AreEqual(expected, interpretedLocation);
    }
    private static IEnumerable<object[]> DetermineNextLocationData
    {
        get
        {
            yield return new object[] { 'f', new Location(0, 1, Direction.North) };
            yield return new object[] { 'l', new Location(0, 0, Direction.West) };
            yield return new object[] { 'r', new Location(0, 0, Direction.East) };
            yield return new object[] { 'b', new Location(0, -1, Direction.North) };
        }
    }
}