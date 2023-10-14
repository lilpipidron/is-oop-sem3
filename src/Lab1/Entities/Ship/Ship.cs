using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public double JumpDistance { get; protected init; }
    public IEngine? Engine { get; protected init; }
    public IJumpEngine? JumpEngine { get; protected init; }
    public IDeflector? Deflector { get; protected set; }
    protected IHull? Stability { get; init; }

    public abstract IEnumerable<IFuel> FuelSpend();

    public abstract double GetAllTime();

    public void AddPhotonDeflector()
    {
        if (Deflector is not null)
        {
            Deflector = new PhotonDeflector(Deflector);
        }
    }

    public Result GetDamage(Damage damage)
    {
        Result result = new Result.ObstacleNotReflected(new Damage(DamageType.Physical, 0));
        if (Deflector is not null)
        {
            result = Deflector.GetDamage(damage);
        }

        if (result is Result.ObstacleReflected)
        {
            return result;
        }

        if (Stability is not null)
        {
            result = Stability.GetDamage(damage);
        }

        return result;
    }
}