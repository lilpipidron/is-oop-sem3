using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public interface IDeflector
{
    public Result GetDamage(Damage damage);
}