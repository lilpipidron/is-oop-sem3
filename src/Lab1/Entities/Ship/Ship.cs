using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public double JumpDistance { get; set; }
    public abstract Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle);
    public abstract Collection<Fuel> FuelSpend();
    public abstract void Move(Environment environment);
    public abstract double AllTime();
}