using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Shuttle : Ship
{
    public Shuttle()
    {
        Engine = new EngineC();
        Stability = new Stability1();
    }
}