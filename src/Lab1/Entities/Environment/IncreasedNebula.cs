using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class IncreasedNebula : Environment
{
    private int _antimatterAmount;

    public IncreasedNebula(int jumpDistance)
    {
        JumpDistance = jumpDistance;
    }

    private int JumpDistance { get; set; }

    public bool CanMove(Engine.JumpEngine? engine)
    {
        return !(engine is null) && engine.JumpDistance >= JumpDistance;
    }

    public void AddAntimatter()
    {
        _antimatterAmount++;
    }

    public override bool CanMove(Engine.Engine engine)
    {
        return false;
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