using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : Ship
{
    public Vaklas()
    {
        Engine = new EngineE();
        JumpEngine = new GammaEngine();
        JumpDistance = JumpEngine.JumpDistance;
        Deflector = new Deflector1();
        Stability = new Hull2();
    }

    public override IEnumerable<IFuel> FuelSpend()
    {
        var allFuel = new Collection<IFuel>();
        if (Engine is not null) allFuel.Add(Engine.Fuel);
        if (JumpEngine is not null) allFuel.Add(JumpEngine.Fuel);

        return allFuel;
    }

    public override double GetAllTime()
    {
        double fullTime = 0;
        if (Engine is not null) fullTime += Engine.Time;
        if (JumpEngine is not null) fullTime += JumpEngine.Time;
        return fullTime;
    }
}