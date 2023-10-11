using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class IncreasedNebula : IEnvironment
{
    private int _antimatterAmount;

    public IncreasedNebula(int jumpDistance)
    {
        JumpDistance = jumpDistance;
    }

    public int JumpDistance { get; init; }

    public void AddAntimatter()
    {
        _antimatterAmount++;
    }

    public IEnumerable<Obstacle.Obstacle> GetAllObstacles()
    {
        var obstacles = new Collection<Obstacle.Obstacle>();
        for (int i = 0; i < _antimatterAmount; i++)
        {
            obstacles.Add(new Antimatter());
        }

        return obstacles;
    }

    public bool TryMove(Ship.Ship ship)
    {
        if (ship.JumpEngine is null)
        {
            return false;
        }

        if (ship.JumpDistance < JumpDistance)
        {
            return false;
        }

        ship.JumpEngine.Move(JumpDistance);
        return true;
    }
}