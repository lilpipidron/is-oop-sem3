using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    public static IEnumerable<object[]> FirstTestShips()
    {
        yield return new object[]
        {
            new Shuttle(),
            new Avgur(),
        };
    }

    public static IEnumerable<object[]> SecondTestShips()
    {
        var valkas2 = new Vaklas();
        valkas2.AddPhotonDeflector();
        yield return new object[]
        {
            new Vaklas(),
            valkas2,
        };
    }

    public static IEnumerable<object[]> ThirdTestShips()
    {
        yield return new object[]
        {
            new Vaklas(),
            new Avgur(),
            new Meredian(),
        };
    }

    [Theory]
    [MemberData(nameof(FirstTestShips))]
    public void MiddleRouteInIncreasedNebula_ShuttleAvgur_ShuttleLostShipAvgurLostShip(Ship ship1, Ship ship2)
    {
        var increasedNebula = new IncreasedNebula(20);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnvironment(increasedNebula);
        Result result1 = travel.Travel(ship1);
        Result result2 = travel.Travel(ship2);
        Assert.Equal(typeof(LostShip), result1.GetType());
        Assert.Equal(typeof(LostShip), result2.GetType());
    }

    [Theory]
    [MemberData(nameof(SecondTestShips))]
    public void IncreasedNebulaWithAntimatter_ValkasAndValkasWithPhotonDeflector_FirstCrewDiedSecondSuccess(Ship ship1, Ship ship2)
    {
        var increasedNebula = new IncreasedNebula(10);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        increasedNebula.AddAntimatter();
        travel.AddEnvironment(increasedNebula);
        Result result1 = travel.Travel(ship1);
        Result result2 = travel.Travel(ship2);
        Assert.Same(typeof(CrewDied), result1.GetType());
        Assert.Same(typeof(Success), result2.GetType());
    }

    [Theory]
    [MemberData(nameof(ThirdTestShips))]
    public void NitrineNebulaWithWhale_ValkasAvgurMeredian_ValkasDestroyAvgurAndMeredianSuccess(Ship ship1, Ship ship2, Ship ship3)
    {
        var nitrineNebula = new NitrineNebula(10);
        nitrineNebula.AddWhale(1);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnvironment(nitrineNebula);
        Result result1 = travel.Travel(ship1);
        Result result2 = travel.Travel(ship2);
        Result result3 = travel.Travel(ship3);
        Assert.True(result1 is DestroyShip && result2 is Success && result3 is Success);
        Assert.Equal(typeof(DestroyShip), result1.GetType());
        Assert.Equal(typeof(Success), result2.GetType());
        Assert.Equal(typeof(Success), result3.GetType());
    }

    [Fact]
    public void ShortRouteInSpace_ShuttleAndVaklas_ChooseShuttle()
    {
        var shuttle = new Shuttle();
        var valkas = new Vaklas();
        var fuelExchange = new FuelExchange(10, 20);
        var space = new Space(30);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnvironment(space);
        var chooseShip = new ChooseShip(travel);
        chooseShip.AddShip(shuttle);
        chooseShip.AddShip(valkas);
        Ship? ship = chooseShip.ChooseBest();
        Assert.Same(typeof(Shuttle), ship?.GetType());
    }

    [Fact]
    public void MiddleRouteInIncreasedNebula_AvgurAndStella_ChooseStella()
    {
        var avgur = new Avgur();
        var stella = new Stella();
        var increasedNebula = new IncreasedNebula(20);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnvironment(increasedNebula);
        var chooseShip = new ChooseShip(travel);
        chooseShip.AddShip(avgur);
        chooseShip.AddShip(stella);
        Ship? ship = chooseShip.ChooseBest();
        Assert.Equal(typeof(Stella), ship?.GetType());
    }

    [Fact]
    public void RouteInNitrineNebula_ShuttleAndValkas_ChooseVaklas()
    {
        var shuttle = new Shuttle();
        var valkas = new Vaklas();
        var nitrineNebula = new NitrineNebula(50000);
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(fuelExchange);
        travel.AddEnvironment(nitrineNebula);
        var chooseShip = new ChooseShip(travel);
        chooseShip.AddShip(shuttle);
        chooseShip.AddShip(valkas);
        Ship? ship = chooseShip.ChooseBest();
        Assert.Same(typeof(Vaklas), ship?.GetType());
    }

    [Fact]
    public void
        RouteWithNitrineNebula_SpaceWithAsteroidMeteorite_IncreasedNebulaWithTwoAntimatter_ValkasWithPhotonDeflector_ResultIsSuccess()
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
        travel.AddEnvironment(increasedNebula);
        travel.AddEnvironment(nitrineNebula);
        travel.AddEnvironment(space);
        Result result = travel.Travel(valkas);
        Assert.Equal(typeof(Success), result.GetType());
    }
}