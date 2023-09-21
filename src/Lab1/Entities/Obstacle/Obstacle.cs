namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public abstract class Obstacle
{
    protected Obstacle() { }

    protected Obstacle(int population)
    {
        Population = population;
    }

    protected Obstacle(int health, int dw)
    {
        HealthPoint = health;
        DoW = dw;
    }

    protected int HealthPoint { get; set; }
    protected int DoW { get; set; }
    protected int Population { get; set; }
}