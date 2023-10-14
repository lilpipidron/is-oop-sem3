using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public abstract record Result
{
    public sealed record CrewDied : Result;

    public sealed record DestroyShip : Result;

    public sealed record LostShip : Result;

    public sealed record ObstacleNotReflected(double Damage) : Result;

    public sealed record ObstacleReflected(double HealthPoint) : Result;

    public sealed record Success(Collection<IFuel> Fuel, Collection<double> Time) : Result;

    public sealed record SuccessEnvironment(IFuel Fuel, double Time) : Result;
}