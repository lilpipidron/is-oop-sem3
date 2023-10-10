using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public abstract class Environment
{
    protected Environment(int jumpDistance)
    {
        JumpDistance = jumpDistance;
    }

    public int JumpDistance { get; private set; }
    public abstract IReadOnlyCollection<Obstacle.Obstacle> GetAllObstacles();
    public abstract bool TryMove(Ship.Ship ship);
}