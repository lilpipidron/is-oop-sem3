using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public double JumpDistance { get; protected init; }
    public Engine.Engine? Engine { get; protected init; }
    public JumpEngine? JumpEngine { get; protected init; }
    public Deflector.IDeflector? Deflector { get; protected set; }
    public bool Emitter { get; protected init; }
    protected IStability? Stability { get; init; }

    public void AddPhotonDeflector()
    {
        if (Deflector is not null)
        {
            Deflector = new PhotonDeflector(Deflector);
        }
    }

    public IEnumerable<IFuel> FuelSpend()
    {
        var allFuel = new Collection<IFuel>();
        if (Engine is not null)
        {
            allFuel.Add(Engine.Fuel);
        }

        if (JumpEngine is not null)
        {
            allFuel.Add(JumpEngine.Fuel);
        }

        return allFuel;
    }

    public double AllTime()
    {
        double fullTime = 0;
        if (Engine is not null)
        {
            fullTime += Engine.Time;
        }

        if (JumpEngine is not null)
        {
            fullTime += JumpEngine.Time;
        }

        return fullTime;
    }

    public Result GetDamage(int damage)
    {
        Result result = new ObstacleNotReflected();
        if (Deflector is not null)
        {
            result = Deflector.GetDamage(damage);
        }

        if (result is ObstacleReflected)
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