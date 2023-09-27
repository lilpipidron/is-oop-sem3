using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class TravelWay
{
    public TravelWay()
    {
        Environments = new List<Environment>();
    }

    private List<Environment> Environments { get; set; }

    public void AddEnviroment(Environment environment)
    {
        Environments.Add(environment);
    }

    public Result Travel(Ship ship)
    {
        foreach (Environment environment in Environments)
        {
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
        }

        return new Success();
    }
}