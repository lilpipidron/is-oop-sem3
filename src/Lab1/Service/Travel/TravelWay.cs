using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class TravelWay
{
    public TravelWay(FuelExchange.FuelExchange fuelExchange)
    {
        Environments = new List<Environment>();
        FuelExchange = fuelExchange;
    }

    private List<Environment> Environments { get; set; }
    private FuelExchange.FuelExchange FuelExchange { get; set; }

    public void AddEnviroment(Environment environment)
    {
        Environments.Add(environment);
    }

    public Result Travel(Ship ship)
    {
        foreach (Environment environment in Environments)
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
        foreach (Fuel fuel in allFuel)
        {
            cost += FuelExchange.TotalCost(fuel);
        }

        return new Success(cost);
    }
}