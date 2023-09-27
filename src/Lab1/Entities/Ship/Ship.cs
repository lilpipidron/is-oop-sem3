namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public abstract Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle);
}