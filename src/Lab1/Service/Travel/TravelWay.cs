using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class TravelWay
{
    private readonly List<IEnvironment> _environments;
    private readonly FuelExchange.FuelExchange _fuelExchange;

    public TravelWay(FuelExchange.FuelExchange fuelExchange)
    {
        _environments = new List<IEnvironment>();
        _fuelExchange = fuelExchange;
    }

    public void AddEnvironment(IEnvironment environment)
    {
        _environments.Add(environment);
    }

    public Result Travel(Ship ship)
    {
        foreach (IEnvironment environment in _environments)
        {
            if (environment.TryMove(ship) is false)
            {
                return new Result.LostShip();
            }

            IEnumerable<IObstacle> obstacle = environment.GetAllObstacles();
            foreach (IObstacle obs in obstacle)
            {
                Result res = obs.DoDamage(ship);
                if (res is not Result.ObstacleReflected)
                {
                    return res;
                }
            }
        }

        IEnumerable<IFuel> allFuel = ship.FuelSpend();
        double cost = allFuel.Sum(fuel => _fuelExchange.TotalCost(fuel));
        double time = ship.GetAllTime();

        return new Result.Success(cost, time);
    }
}