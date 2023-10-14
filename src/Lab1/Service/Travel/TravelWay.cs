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

    public Result Travel(Ship ship)
    {
        Result success = new Result.Success(new Collection<IFuel>(), new Collection<double>());
        foreach (IEnvironment environment in _environments)
        {
            Result result = environment.TryOvercome(ship);

            if (result is not Result.SuccessEnvironment successEnvironment ||
                success is not Result.Success resultSuccess) return result;
            resultSuccess.Fuel.Add(successEnvironment.Fuel);
            resultSuccess.Time.Add(successEnvironment.Time);
        }

        return success;
    }
}