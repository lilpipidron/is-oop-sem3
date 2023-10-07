using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Stability;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class Ship
{
    public double JumpDistance { get; protected init; }
    public Engine.Engine? Engine { get; protected init; }
    public JumpEngine? JumpEngine { get; protected init; }
    public Model.Deflector.Deflector? Deflector { get; protected set; }
    public Stability? Stability { get; protected set; }
    public abstract Obstacle.Obstacle? GetDamage(Obstacle.Obstacle obstacle);

    public void AddPhotonDeflector()
    {
        if (Deflector is not null)
        {
            Deflector = new PhotonDeflector(Deflector);
        }
    }

    public IEnumerable<Fuel> FuelSpend()
    {
        var allFuel = new Collection<Fuel>();
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
}