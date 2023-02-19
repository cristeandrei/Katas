
namespace MarsRover;
public class Rover
{
    private readonly INavigationSystem _navigation;
    private readonly IObstacleSensor _detector;

    public Location Position { get; private set; }

    public Rover(Location start, INavigationSystem interpreter, IObstacleSensor obstacleDetector)
    {
        _navigation = interpreter;
        _detector = obstacleDetector;
        Position = start;

    }

    public void ReciveCommands(char[] commands)
    {
        foreach (var command in commands)
        {
            var next = _navigation.NextLocation(command, Position);

            if (_detector.FoundObstacle(next))
                break;

            Position = next;
        }
    }
}
