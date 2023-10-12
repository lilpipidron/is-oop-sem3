using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class NitrineNebula : IEnvironment
{
    private readonly List<CosmoWhale> _whales;
    private readonly int _distance;

    public NitrineNebula(int distance)
    {
        _distance = distance;
        _whales = new List<CosmoWhale>();
    }

    public void AddWhale(int amount)
    {
        _whales.Add(new CosmoWhale(amount));
    }

    public IEnumerable<Obstacle.IObstacle> GetAllObstacles()
    {
        return _whales;
    }

    public bool TryMove(Ship.Ship ship)
    {
        switch (ship.Engine)
        {
            case null:
                return false;
            case EngineE:
                ship.Engine.Move(_distance);
                return true;
            default:
                return ship.Engine.SpeedDown(_distance);
        }
    }
}