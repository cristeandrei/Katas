namespace MarsRover;
public class NavigationSystem : INavigationSystem
{
    private readonly INavigationInterpreter _interpreter;
    private const int _X = 10;
    private const int _Y = 10;

    public NavigationSystem(INavigationInterpreter interpreter)
    {
        _interpreter = interpreter;
    }

    public Location NextLocation(char command, Location current)
    {
        var next = _interpreter.DetermineNextLocation(command, current);

        return Calibrate(next);
    }

    private Location Calibrate(Location next)
    {
        int x = next.X switch
        {
            < 0 => _X,
            > 10 => 0,
            _ => next.X,
        };
        int y = next.Y switch
        {
            < 0 => _Y,
            > 10 => 0,
            _ => next.Y,
        };
        return next with { X = x, Y = y };
    }
}
