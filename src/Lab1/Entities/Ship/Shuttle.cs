using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Shuttle : Ship
{
    public Shuttle()
        : base(new EngineC())
    {
        Stability = new Hull1();
    }
}