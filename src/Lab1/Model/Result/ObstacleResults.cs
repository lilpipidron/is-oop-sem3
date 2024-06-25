namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public record ObstacleResults
{
    private ObstacleResults()
    {
    }

    public sealed record ObstacleNotReflected(double Damage) : ObstacleResults;

    public sealed record ObstacleReflected(double HealthPoint) : ObstacleResults;
}