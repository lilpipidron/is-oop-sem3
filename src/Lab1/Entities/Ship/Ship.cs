namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public double JumpDistance { get; set; }
    public abstract Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle);
}