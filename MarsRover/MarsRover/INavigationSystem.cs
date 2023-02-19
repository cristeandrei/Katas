namespace MarsRover;

public interface INavigationSystem
{
    Location NextLocation(char command, Location current);
}