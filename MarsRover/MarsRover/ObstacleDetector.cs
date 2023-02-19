namespace MarsRover;
internal class ObstacleSensor : IObstacleSensor
{
    public bool FoundObstacle(Location next)
    {
        return ScanForObstacle();
    }

    private bool ScanForObstacle() => new Random().Next(2) == 1;
}
