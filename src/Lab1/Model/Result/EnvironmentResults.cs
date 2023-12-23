using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

public record EnvironmentResults : TravelResults
{
    public sealed record SuccessEnvironment(IFuel Fuel, double Time) : EnvironmentResults;

    public sealed record CrewDied : EnvironmentResults;

    public sealed record DestroyShip : EnvironmentResults;

    public sealed record LostShip : EnvironmentResults;
}