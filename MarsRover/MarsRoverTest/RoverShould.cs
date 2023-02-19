using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

using static NSubstitute.Arg;

namespace MarsRoverTest;

[TestClass()]
public class RoverShould
{
    private readonly INavigationSystem _navigation;
    private readonly IObstacleSensor _detector;
    private static Location start;
    public RoverShould()
    {
        _navigation = Substitute.For<INavigationSystem>();
        _detector = Substitute.For<IObstacleSensor>();
        start = new Location(0, 0, Direction.North);
    }

    [DataTestMethod()]
    [DataRow(new char[] { 'f', 'f', 'f' })]
    public void BeAbleToMove(char[] commands)
    {
        var rover = new Rover(start, _navigation, _detector);

        rover.ReciveCommands(commands);

        Received.InOrder(() =>
        {
            foreach (var command in commands)
            {
                _navigation.NextLocation(command, Any<Location>());
                _detector.FoundObstacle(Any<Location>());
            }
        });
    }

    [DataTestMethod()]
    [DynamicData(nameof(StopIfEncounterAnObjectData))]
    public void StopIfEncounterAnObstacle(Location expected, char[] commands)
    {
        _detector.FoundObstacle(Any<Location>()).Returns(true);
        _navigation.NextLocation(Any<char>(), Any<Location>()).Returns(expected);

        var rover = new Rover(start, _navigation, _detector);

        rover.ReciveCommands(commands);

        Location currentPosition = rover.Position;

        Assert.AreNotEqual(expected, currentPosition);
    }

    private static IEnumerable<object[]> StopIfEncounterAnObjectData
    {
        get
        {
            yield return new object[] { new Location(0, 3, Direction.North), new char[] { 'f', 'f', 'f' } };
        }
    }
}
