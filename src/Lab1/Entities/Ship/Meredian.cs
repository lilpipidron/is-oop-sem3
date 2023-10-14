using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : Ship, IShipWithEmitter
{
    public Meredian()
    {
        Engine = new EngineE();
        Deflector = new Deflector2();
        Stability = new Hull2();
    }

    public override IEnumerable<IFuel> FuelSpend()
    {
        var allFuel = new Collection<IFuel>();
        if (Engine is not null) allFuel.Add(Engine.Fuel);

        return allFuel;
    }

    public override double GetAllTime()
    {
        double fullTime = 0;
        if (Engine is not null) fullTime += Engine.Time;
        return fullTime;
    }
}