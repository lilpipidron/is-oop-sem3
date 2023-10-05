using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enivorment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    [Fact]
    public void MiddleRouteInIncreasedNebulaShuttleAvgurShuttleLostShipAvgurLostShip()
    {
        var shuttle = new Shuttle();
        var avgur = new Avgur();
        var increasedNebula = new IncreasedNebula(20);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnviroment(increasedNebula);
        Result result1 = travel.Travel(shuttle);
        Result result2 = travel.Travel(avgur);
        Assert.True(result1 is LostShip && result2 is LostShip);
    }

    [Fact]
    public void IncreasedNebulaWithAntimatterValkasAndValkasWithPhotonDeflectorFirstCrewDiedSecondSuccess()
    {
        var valkas1 = new Vaklas();
        var valkas2 = new Vaklas();
        valkas2.AddPhotonDeflector();
        var increasedNebula = new IncreasedNebula(10);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        increasedNebula.AddAntimatter();
        travel.AddEnviroment(increasedNebula);
        Result result1 = travel.Travel(valkas1);
        Result result2 = travel.Travel(valkas2);
        Assert.True(result1 is CrewDied && result2 is Success);
    }

    [Fact]
    public void NitrineNebulaWithWhaleValkasAvgurMeredianValkasDestroyAvgurAndMeredianSuccess()
    {
        var valkas = new Vaklas();
        var avgur = new Avgur();
        var meredian = new Meredian();
        var nitrineNebula = new NitrineNebula(10);
        nitrineNebula.AddWhale();
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnviroment(nitrineNebula);
        Result result1 = travel.Travel(valkas);
        Result result2 = travel.Travel(avgur);
        Result result3 = travel.Travel(meredian);
        Assert.True(result1 is DestroyShip && result2 is Success && result3 is Success);
    }

    [Fact]
    public void ShortRouteInSpaceShuttleAndVaklasChooseShuttle()
    {
        var shuttle = new Shuttle();
        var valkas = new Vaklas();
        var fuelExchange = new FuelExchange(10, 20);
        var space = new Space(30);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnviroment(space);
        var chooseShip = new ChooseShip(travel);
        chooseShip.AddShip(shuttle);
        chooseShip.AddShip(valkas);
        Ship? ship = chooseShip.ChooseBest();
        Assert.True(ship is Shuttle);
    }

    [Fact]
    public void MiddleRouteInIncreasedNebulaAvgurAndStellaChooseStella()
    {
        var avgur = new Avgur();
        var stella = new Stella();
        var increasedNebula = new IncreasedNebula(20);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnviroment(increasedNebula);
        var chooseShip = new ChooseShip(travel);
        chooseShip.AddShip(avgur);
        chooseShip.AddShip(stella);
        Ship? ship = chooseShip.ChooseBest();
        Assert.True(ship is Stella);
    }

    [Fact]
    public void RouteInNitrineNebulaChooseVaklas()
    {
        var shuttle = new Shuttle();
        var valkas = new Vaklas();
        var nitrineNebula = new NitrineNebula(50000);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnviroment(nitrineNebula);
        var chooseShip = new ChooseShip(travel);
        chooseShip.AddShip(shuttle);
        chooseShip.AddShip(valkas);
        Ship? ship = chooseShip.ChooseBest();
        Assert.True(ship is Vaklas);
    }

    [Fact]
    public void RouteWithNitrineNebulaSpaceWithAsteroidMeteoriteIncreasedNebulaWithTwoAntimatterValkasWithPhotonDeflectorResultIsSuccess()
    {
        var valkas = new Vaklas();
        valkas.AddPhotonDeflector();
        var nitrineNebula = new NitrineNebula(20);
        var space = new Space(20);
        space.AddAsteroid();
        space.AddMeteorite();
        var increasedNebula = new IncreasedNebula(20);
        increasedNebula.AddAntimatter();
        increasedNebula.AddAntimatter();
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnviroment(increasedNebula);
        travel.AddEnviroment(nitrineNebula);
        travel.AddEnviroment(space);
        Result result = travel.Travel(valkas);
        Assert.True(result is Success);
    }
}