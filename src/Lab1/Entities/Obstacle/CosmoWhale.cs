using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class CosmoWhale : IObstacle
{
    private const int Damage = 400;
    private readonly int _amount;

    public CosmoWhale(int amount)
    {
        _amount = amount;
    }

    public Result DoDamage(Ship.Ship ship)
    {
        if (ship.Emitter)
        {
            return new ObstacleReflected();
        }

        Result result = ship.GetDamage(Damage * _amount);
        return result is ObstacleNotReflected ? new DestroyShip() : result;
    }
}