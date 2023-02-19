namespace MarsRoverTest;

[TestClass()]
public class NavigationSystemShould
{
    private readonly INavigationInterpreter _interpreter;
    public NavigationSystemShould()
    {
        _interpreter = Substitute.For<INavigationInterpreter>();
    }

    [DataTestMethod()]
    [DynamicData(nameof(CalibrateNextLocationIfPlanetIsRoundData))]
    public void CalibrateNextLocationIfPlanetIsRound(char command, Location current, Location determinedNext, Location expected)
    {
        _interpreter.DetermineNextLocation(Any<char>(), Any<Location>()).Returns(determinedNext);

        var navigation = new NavigationSystem(_interpreter);

        var next = navigation.NextLocation(command, current);

        Assert.AreEqual(expected, next);

    }

    private static IEnumerable<object[]> CalibrateNextLocationIfPlanetIsRoundData
    {
        get
        {
            yield return new object[] { 'f', new Location(10, 10, Direction.North), new Location(10, 11, Direction.North), new Location(10, 0, Direction.North) };
            yield return new object[] { 'f', new Location(0, 0, Direction.West), new Location(-1, 0, Direction.West), new Location(10, 0, Direction.West) };
            yield return new object[] { 'f', new Location(0, 0, Direction.South), new Location(0, -1, Direction.South), new Location(0, 10, Direction.South) };
            yield return new object[] { 'f', new Location(10, 10, Direction.East), new Location(11, 10, Direction.East), new Location(0, 10, Direction.East) };
            yield return new object[] { 'b', new Location(0, 0, Direction.North), new Location(0, -1, Direction.North), new Location(0, 10, Direction.North) };
            yield return new object[] { 'b', new Location(10, 10, Direction.West), new Location(11, 10, Direction.West), new Location(0, 10, Direction.West) };
            yield return new object[] { 'b', new Location(10, 10, Direction.South), new Location(10, 11, Direction.South), new Location(10, 0, Direction.South) };
            yield return new object[] { 'b', new Location(0, 0, Direction.East), new Location(-1, 0, Direction.East), new Location(10, 0, Direction.East) };
        }
    }
}