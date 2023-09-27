using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class Space : Environment
{
    private int _asteroidAmount;

    private int _meteoriteAmount;

    public void AddAsteroid()
    {
        _asteroidAmount++;
    }

    public void AddMeteorite()
    {
        _meteoriteAmount++;
    }

    public override bool CanMove(Engine.Engine engine)
    {
        return true;
    }

    public override Collection<Obstacle.Obstacle> GetAllObstacles()
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
}