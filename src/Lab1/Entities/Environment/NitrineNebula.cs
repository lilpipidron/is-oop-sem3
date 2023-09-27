using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class NitrineNebula : Environment
{
    private int _whaleAmount;

    public void AddWhale()
    {
        _whaleAmount++;
    }

    public override bool CanMove(Engine.Engine engine)
    {
        return engine is EngineE;
    }

    public override Collection<Obstacle.Obstacle> GetAllObstacles()
    {
        var obstacles = new Collection<Obstacle.Obstacle>();
        for (int i = 0; i < _whaleAmount; i++)
        {
            obstacles.Add(new CosmoWhale());
        }

        return obstacles;
    }
}