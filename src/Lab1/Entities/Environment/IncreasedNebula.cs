using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class IncreasedNebula : Environment.Environment
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

    public override bool TryMove(Ship.Ship ship)
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