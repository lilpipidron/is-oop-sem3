using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public interface IHull
{
    public Result HandleDamage(double damage);
}