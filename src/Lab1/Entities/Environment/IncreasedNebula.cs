using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class IncreasedNebula : IEnvironment
{
    private readonly int _jumpDistance;
    private int _antimatterAmount;

    public IncreasedNebula(int jumpDistance)
    {
        _jumpDistance = jumpDistance;
    }

    public void AddAntimatter()
    {
        _antimatterAmount++;
    }

    public IEnumerable<IObstacle> GetAllObstacles()
    {
        var obstacles = new Collection<IObstacle>();
        for (int i = 0; i < _antimatterAmount; i++)
        {
            obstacles.Add(new AntimatterFlash());
        }

        return obstacles;
    }

    public bool TryMove(Ship.Ship ship)
    {
        if (ship.JumpEngine is null)
        {
            return false;
        }

        if (ship.JumpDistance < _jumpDistance)
        {
            return false;
        }

        ship.JumpEngine.Move(_jumpDistance);
        return true;
    }
}