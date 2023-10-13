using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Stability;

public interface IStability
{
    public Result GetDamage(Model.Damage.Damage damage);
}