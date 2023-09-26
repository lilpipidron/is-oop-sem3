using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class NitrineNebula : Enivorment
{
    private int _whaleAmount;

    public void AddWhale()
    {
        _whaleAmount++;
    }

    public override bool CanMove(Engine.Engine engine)
    {
        return engine is EngineE;
    }
}