using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

public abstract class Stability
{
    protected Stability(int healthPoints, int asteroidDamage, int meteoriteDamage)
    {
        HealthPoints = healthPoints;
        AsteroidDamage = asteroidDamage;
        MeteoriteDamage = meteoriteDamage;
        Alive = true;
    }

    private int HealthPoints { get; set; }
    private int AsteroidDamage { get; }
    private int MeteoriteDamage { get; }
    private bool Alive { get; set; }

    public Obstacle? GetDamage(Obstacle? obstacle)
    {
        if (!Alive || obstacle == null || obstacle is Antimatter || obstacle is CosmoWhale)
        {
            return obstacle;
        }

        switch (obstacle)
        {
            case Asteroid:
                obstacle.GetDamage(double.Min(AsteroidDamage, HealthPoints) / AsteroidDamage);
                HealthPoints -= AsteroidDamage;
                break;
            case Meteorite:
                obstacle.GetDamage(double.Min(MeteoriteDamage, HealthPoints) / MeteoriteDamage);
                HealthPoints -= MeteoriteDamage;
                break;
        }

        if (HealthPoints <= 0)
        {
            Alive = false;
        }

        return Alive ? null : obstacle;
    }
}