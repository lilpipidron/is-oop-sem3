using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public double JumpDistance { get; protected init; }
    public abstract Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle);
    public abstract IEnumerable<Fuel> FuelSpend();
    public abstract void Move(Environment.Environment environment);
    public abstract double AllTime();
}