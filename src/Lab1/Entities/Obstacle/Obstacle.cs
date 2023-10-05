namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class Obstacle
{
    private double _healthPoint;
    private int _dow;
    protected Obstacle() { }

    protected Obstacle(double health, int dw)
    {
        _healthPoint = health;
        _dow = dw;
    }

    public void GetDamage(double damageCoefficient)
    {
        _healthPoint -= _healthPoint * damageCoefficient;
    }
}