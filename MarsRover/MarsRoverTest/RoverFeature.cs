using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

namespace MarsRoverTest;

[TestClass()]
public class RoverFeature
{
    private Location _start;
    private readonly IObstacleSensor _detector;
    public RoverFeature()
    {
        _start = new Location(0, 0, Direction.North);
        _detector = Substitute.For<IObstacleSensor>();
    }

    [DataTestMethod()]
    [DynamicData(nameof(MoveBackToTheStartPointData))]
    public void MoveBackToTheStartPoint(char[] commands)
    {
        _detector.FoundObstacle(Arg.Any<Location>()).Returns(false);

        var rover = new Rover(_start, new NavigationSystem(new NavigationInterpreter()), _detector);

        rover.ReciveCommands(commands);

        Location currentPosition = rover.Position;

        Assert.AreEqual(_start, currentPosition);
    }

    private static IEnumerable<object[]> MoveBackToTheStartPointData
    {
        get
        {
            yield return new object[] { new char[] { 'f', 'l', 'f', 'r', 'b', 'r', 'f', 'l' } };
            yield return new object[] { new char[] { 'b', 'r', 'f', 'l', 'f', 'l', 'f', 'r' } };
        }
    }
}