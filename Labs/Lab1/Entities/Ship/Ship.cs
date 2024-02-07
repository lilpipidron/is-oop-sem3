using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    protected Ship(IEngine engine)
    {
        Engine = engine;
    }

    public IEngine Engine { get; }
    public IJumpEngine? JumpEngine { get; protected init; }
    public IDeflector? Deflector { get; protected init; }
    protected IHull? Stability { get; init; }

    public ObstacleResults HandleDamage(int damage)
    {
        ObstacleResults result = new ObstacleResults.ObstacleNotReflected(0);
        if (Deflector is not null)
        {
            result = Deflector.GetDamage(damage);
        }

        if (result is ObstacleResults.ObstacleReflected)
        {
            return result;
        }

        if (Stability is not null)
        {
            result = Stability.HandleDamage(damage);
        }

        return result;
    }
}