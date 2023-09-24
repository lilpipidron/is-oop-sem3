namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class Obstacle
{
    private double _healthPoint;
    protected Obstacle() { }

    protected Obstacle(int population)
    {
        Population = population;
    }

    protected Obstacle(double health, int dw)
    {
        _healthPoint = health;
        DoW = dw;
    }

    protected int DoW { get; set; }

    protected int Population { get; set; }

    public void GetDamage(double damageCoefficient)
    {
        _healthPoint -= _healthPoint * damageCoefficient;
    }
}