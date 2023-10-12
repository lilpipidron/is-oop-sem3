namespace Itmo.ObjectOrientedProgramming.Lab1.Model.Strategy;

public interface IStrategy
{
    public Service.Result.Result TakeDamage(Damage.Damage damage, double healthPoint);
}