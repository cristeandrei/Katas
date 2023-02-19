namespace MarsRover;

public interface INavigationInterpreter
{
    Location DetermineNextLocation(char command, Location location);
}