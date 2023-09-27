using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    [Fact]
    public void Test1()
    {
        var shuttle = new Shuttle();
        var avgur = new Avgur();
        var increasedNebula = new IncreasedNebula(20);
        var travel = new TravelWay();
        travel.AddEnviroment(increasedNebula);
        Result result1 = travel.Travel(shuttle);
        Result result2 = travel.Travel(avgur);
        Assert.True(result1 is LostShip && result2 is LostShip);
    }

    [Fact]
    public void Test2()
    {
        var valkas1 = new Vaklas();
        var valkas2 = new Vaklas();
        valkas2.AddPhotonDeflector();
        var increasedNebula = new IncreasedNebula(10);
        var travel = new TravelWay();
        increasedNebula.AddAntimatter();
        travel.AddEnviroment(increasedNebula);
        Result result1 = travel.Travel(valkas1);
        Result result2 = travel.Travel(valkas2);
        Assert.True(result1 is CrewDied && result2 is Success);
    }

    [Fact]
    public void Test3()
    {
        var valkas = new Vaklas();
        var avgur = new Avgur();
        var meredian = new Meredian();
        var nitrineNebula = new NitrineNebula();
        nitrineNebula.AddWhale();
        var travel = new TravelWay();
        travel.AddEnviroment(nitrineNebula);
        Result result1 = travel.Travel(valkas);
        Result result2 = travel.Travel(avgur);
        Result result3 = travel.Travel(meredian);
        Assert.True(result1 is DestroyShip && result2 is Success && result3 is Success);
    }
}