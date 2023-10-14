namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public abstract record Result
{
    private Result()
    {
    }

    public sealed record CrewDied : Result;

    public sealed record DestroyShip : Result;

    public sealed record LostShip : Result;

    public sealed record ObstacleNotReflected(Damage.Damage Damage) : Result;

    public sealed record ObstacleReflected(double HealthPoint) : Result;

    public sealed record Success(double FlyCost, double FlyTime) : Result;
}