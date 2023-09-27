using System;
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

    public void Travel(Ship ship)
    {
        if (ship == null)
        {
            return;
        }

        foreach (Environment environment in Environments)
        {
            Collection<Obstacle> obstacle = environment.GetAllObstacles();
            foreach (Obstacle obs in obstacle)
            {
                switch (ship.GetDamage(obs))
                {
                    case Antimatter:
                        throw new AggregateException("The crew died");
                    case null:
                        break;
                    default:
                        throw new AggregateException("The ship is destroyed");
                }
            }
        }
    }
}