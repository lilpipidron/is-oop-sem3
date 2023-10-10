using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class TravelWay
{
    private readonly List<Environment> _environments;
    private readonly FuelExchange.FuelExchange _fuelExchange;

    public TravelWay(FuelExchange.FuelExchange fuelExchange)
    {
        _environments = new List<Environment>();
        _fuelExchange = fuelExchange;
    }

    public void AddEnvironment(Environment environment)
    {
        _environments.Add(environment);
    }

    public Result.Result Travel(Ship ship)
    {
        foreach (Environment environment in _environments)
        {
            if (environment.TryMove(ship) is false)
            {
                return new LostShip();
            }

            IReadOnlyCollection<Obstacle> obstacle = environment.GetAllObstacles();
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
        double cost = 0;
        double time = 0;
        cost = allFuel.Sum(fuel => _fuelExchange.TotalCost(fuel));
        time = ship.AllTime();

        return new Success(cost, time);
    }
}