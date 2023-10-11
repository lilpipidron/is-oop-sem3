using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class Space : IEnvironment
{
    private int _asteroidAmount;
    private int _meteoriteAmount;

    public Space(int distance)
    {
        JumpDistance = distance;
    }

    public int JumpDistance { get; init; }

    public void AddAsteroid()
    {
        _asteroidAmount++;
    }

    public void AddMeteorite()
    {
        _meteoriteAmount++;
    }

    public IEnumerable<Obstacle.Obstacle> GetAllObstacles()
    {
        var obstacles = new Collection<Obstacle.Obstacle>();
        for (int i = 0; i < _asteroidAmount; i++)
        {
            obstacles.Add(new Asteroid());
        }

        for (int i = 0; i < _meteoriteAmount; i++)
        {
            obstacles.Add(new Meteorite());
        }

        return obstacles;
    }

    public bool TryMove(Ship.Ship ship)
    {
        if (ship.Engine is null)
        {
            return false;
        }

        ship.Engine.Move(JumpDistance);
        return true;
    }
}