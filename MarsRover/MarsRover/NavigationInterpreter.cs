namespace MarsRover;

public class NavigationInterpreter : INavigationInterpreter
{
    public Location DetermineNextLocation(char command, Location location) => command switch
    {
        'f' => Forward(location),
        'b' => Backward(location),
        'r' => RotateRight(location),
        'l' => RotateLeft(location),
        _ => throw new NotSupportedException(),
    };

    private Location RotateRight(Location current)
    {
        return current with
        {
            Facing = current.Facing switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new NotSupportedException()
            }
        };
    }

    private Location RotateLeft(Location current) => current with
    {
        Facing = current.Facing switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            _ => throw new NotSupportedException()
        }
    };

    private Location Forward(Location current) => current.Facing switch
    {
        Direction.North => current with { Y = current.Y + 1 },
        Direction.South => current with { Y = current.Y - 1 },
        Direction.West => current with { X = current.X - 1 },
        Direction.East => current with { X = current.X + 1 },
        _ => throw new NotSupportedException()
    };

    private Location Backward(Location current)
    {
        if (current.Facing is Direction.North) return current with { Y = current.Y - 1 };
        if (current.Facing is Direction.South) return current with { Y = current.Y + 1 };
        if (current.Facing is Direction.West) return current with { X = current.X + 1 };
        if (current.Facing is Direction.East) return current with { X = current.X - 1 };
        throw new NotSupportedException();
    }
}