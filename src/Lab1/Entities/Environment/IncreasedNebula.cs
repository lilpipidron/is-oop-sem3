using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class IncreasedNebula : Environment
{
    private int _antimatterAmount;

    public IncreasedNebula(int jumpDistance)
        : base(jumpDistance)
    {
    }

    public void AddAntimatter()
    {
        _antimatterAmount++;
    }

    public override Collection<Obstacle.Obstacle> GetAllObstacles()
    {
        var obstacles = new Collection<Obstacle.Obstacle>();
        for (int i = 0; i < _antimatterAmount; i++)
        {
            obstacles.Add(new Antimatter());
        }

        return obstacles;
    }
}