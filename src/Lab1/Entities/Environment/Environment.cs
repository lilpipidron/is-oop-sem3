using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public abstract class Environment
{
    protected Environment()
    {
    }

    protected Environment(int jumpDistance)
    {
        JumpDistance = jumpDistance;
    }

    public int JumpDistance { get; private set; }
    public abstract Collection<Obstacle.Obstacle> GetAllObstacles();
}