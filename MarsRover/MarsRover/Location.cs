namespace MarsRover;

public record struct Location
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Facing { get; set; }
    public Location(int x, int y, Direction facing)
    {
        X = x;
        Y = y;
        Facing = facing;
    }
}