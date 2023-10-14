namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

public interface IStrategy
{
    public Result.Result TakeDamage(Damage.Damage damage, double healthPoint);
}