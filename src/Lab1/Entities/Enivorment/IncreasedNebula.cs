namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class IncreasedNebula : Enivorment
{
    private int _antimatterAmount;

    public static bool CanMove(Engine.JumpEngine? engine)
    {
        return !(engine is null);
    }

    public void AddAntimatter()
    {
        _antimatterAmount++;
    }

    public override bool CanMove(Engine.Engine engine)
    {
        return false;
    }
}