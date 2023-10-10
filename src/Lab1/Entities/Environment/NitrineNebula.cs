using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class NitrineNebula : Environment.Environment
{
    private int _whaleAmount;

    public NitrineNebula(int distance)
        : base(distance)
    {
    }

    public void AddWhale()
    {
        _whaleAmount++;
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

    public override bool TryMove(Ship.Ship ship)
    {
        switch (ship.Engine)
        {
            case null:
                return false;
            case EngineE:
                ship.Engine.Move(JumpDistance);
                return true;
            default:
                return ship.Engine.SpeedDown(JumpDistance);
        }
    }
}