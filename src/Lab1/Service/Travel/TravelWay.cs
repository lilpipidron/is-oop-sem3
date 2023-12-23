using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class TravelWay
{
    private readonly ReadOnlyCollection<IEnvironment> _environments;
    private readonly FuelExchange.FuelExchange _fuelExchange;

    public TravelWay(FuelExchange.FuelExchange fuelExchange, ReadOnlyCollection<IEnvironment> environments)
    {
        _environments = environments;
        _fuelExchange = fuelExchange;
    }

    public TravelResults Travel(Ship ship)
    {
        var allFuel = new Collection<IFuel>();
        var allTime = new Collection<double>();
        foreach (IEnvironment environment in _environments)
        {
            EnvironmentResults result = environment.TryOvercome(ship);

            if (result is not EnvironmentResults.SuccessEnvironment successEnvironment) return result;
            allFuel.Add(successEnvironment.Fuel);
            allTime.Add(successEnvironment.Time);
        }

        return new TravelResults.Success(allFuel, allTime);
    }
}