using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment.Environment;

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

    public void AddEnviroment(Environment environment)
    {
        _environments.Add(environment);
    }

    public Result Travel(Ship ship)
    {
        foreach (Environment environment in _environments)
        {
            if ((ship is Shuttle || ship is Meredian) && environment is IncreasedNebula)
            {
                return new LostShip();
            }

            if (environment is IncreasedNebula)
            {
                if (environment.JumpDistance > ship.JumpDistance)
                {
                    return new LostShip();
                }
            }

            Collection<Obstacle> obstacle = environment.GetAllObstacles();
            foreach (Obstacle obs in obstacle)
            {
                switch (ship.GetDamage(obs))
                {
                    case Antimatter:
                        return new CrewDied();
                    case null:
                        break;
                    default:
                        return new DestroyShip();
                }
            }

            ship.Move(environment);
        }

        Collection<Fuel> allFuel = ship.FuelSpend();
        double cost = 0;
        cost = allFuel.Sum(fuel => _fuelExchange.TotalCost(fuel));

        return new Success(cost);
    }
}