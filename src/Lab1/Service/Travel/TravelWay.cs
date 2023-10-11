using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

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

    public Result.Result Travel(Ship ship)
    {
        foreach (IEnvironment environment in _environments)
        {
            if (environment.TryMove(ship) is false)
            {
                return new LostShip();
            }

            IEnumerable<Obstacle> obstacle = environment.GetAllObstacles();
            foreach (Obstacle obs in obstacle)
            {
                Result.Result res = obs.DoDamage(ship);
                if (res is not ObstacleReflected)
                {
                    return res;
                }
            }
        }

        IEnumerable<Fuel> allFuel = ship.FuelSpend();
        double cost = allFuel.Sum(fuel => _fuelExchange.TotalCost(fuel));
        double time = ship.AllTime();

        return new Success(cost, time);
    }
}