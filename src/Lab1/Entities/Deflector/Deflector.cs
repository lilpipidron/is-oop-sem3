using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Deflector;

public abstract class Deflector
{
    private readonly int _asteroidDamage;
    private readonly int _meteoriteDamage;
    private readonly int _whaleDamage;
    private int _healthPoints;
    private bool _works;

    protected Deflector()
    {
    }

    protected Deflector(int asteroidDamage, int meteoriteDamage, int whaleDamage, int healthPoints)
    {
        _asteroidDamage = asteroidDamage;
        _meteoriteDamage = meteoriteDamage;
        _healthPoints = healthPoints;
        _whaleDamage = whaleDamage;
        _works = true;
    }

    public virtual Obstacle? GetDamage(Obstacle? obstacle)
    {
        if (_works == false || obstacle is null)
        {
            return obstacle;
        }

        switch (obstacle)
        {
            case Asteroid:
                obstacle.GetDamage(double.Min(_asteroidDamage, _healthPoints) / _asteroidDamage);
                _healthPoints -= _asteroidDamage;
                break;
            case Meteorite:
                obstacle.GetDamage(double.Min(_meteoriteDamage, _healthPoints) / _meteoriteDamage);
                _healthPoints -= _meteoriteDamage;
                break;
            case CosmoWhale:
                obstacle.GetDamage(double.Min(_whaleDamage, _healthPoints) / _whaleDamage);
                _healthPoints -= _whaleDamage;
                if (_whaleDamage == 0)
                {
                    _works = false;
                    return obstacle;
                }

                break;
            case Antimatter:
                if (this is PhotonDeflector photonDeflector)
                {
                    return photonDeflector.Use() is false ? obstacle : null;
                }

                return obstacle;
        }

        if (_healthPoints >= 0) return null;
        _works = false;
        return obstacle;
    }
}