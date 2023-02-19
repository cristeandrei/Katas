namespace MarsRover;

public interface IObstacleSensor
{
    bool FoundObstacle(Location next);
}