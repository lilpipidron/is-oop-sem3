namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;

public class Space : Enivorment
{
    private int _asteroidAmount;
    private int _meteorinteAmount;

    public void AddAsteroid()
    {
        _asteroidAmount++;
    }

    public void AddMeteorite()
    {
        _meteorinteAmount++;
    }

    public override bool CanMove(Engine.Engine engine)
    {
        return true;
    }
}