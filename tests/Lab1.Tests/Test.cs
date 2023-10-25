using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
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
            new Avgur(new Deflector3()),
        };
    }

    public static IEnumerable<object[]> SecondTestShips()
    {
        var deflector1 = new PhotonDeflector(new Deflector1());
        var valkas2 = new Vaklas(deflector1);
        yield return new object[]
        {
            new Vaklas(new Deflector1()),
            valkas2,
        };
    }

    public static IEnumerable<object[]> ThirdTestShips()
    {
        yield return new object[]
        {
            new Vaklas(new Deflector1()),
            new Avgur(new Deflector3()),
            new Meredian(new Deflector2()),
        };
    }

    [Theory]
    [MemberData(nameof(FirstTestShips))]
    public void MiddleRouteInIncreasedNebula_ShuttleAvgur_ShuttleLostShipAvgurLostShip(Ship ship1, Ship ship2)
    {
        var increasedNebula = new IncreasedNebula(
            20,
            new Collection<IIncreasedNebulaObstacle>());
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { increasedNebula }));

        TravelResults result1 = travel.Travel(ship1);
        TravelResults result2 = travel.Travel(ship2);
        Assert.Equal(typeof(EnvironmentResults.LostShip), result1.GetType());
        Assert.Equal(typeof(EnvironmentResults.LostShip), result2.GetType());
    }

    [Theory]
    [MemberData(nameof(SecondTestShips))]
    public void IncreasedNebulaWithAntimatter_ValkasAndValkasWithPhotonDeflector_FirstCrewDiedSecondSuccess(
        Ship ship1,
        Ship ship2)
    {
        var increasedNebula = new IncreasedNebula(
            10,
            new Collection<IIncreasedNebulaObstacle>(new IIncreasedNebulaObstacle[] { new AntimatterFlash() }));
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { increasedNebula }));
        TravelResults result1 = travel.Travel(ship1);
        TravelResults result2 = travel.Travel(ship2);
        Assert.Same(typeof(EnvironmentResults.CrewDied), result1.GetType());
        Assert.Same(typeof(TravelResults.Success), result2.GetType());
    }

    [Theory]
    [MemberData(nameof(ThirdTestShips))]
    public void NitrineNebulaWithWhale_ValkasAvgurMeredian_ValkasDestroyAvgurAndMeredianSuccess(
        Ship ship1,
        Ship ship2,
        Ship ship3)
    {
        var nitrineNebula = new NitrineNebula(
            10,
            new Collection<INitrineNebulaObstacle>(new INitrineNebulaObstacle[] { new CosmoWhale(1) }));
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { nitrineNebula }));
        TravelResults result1 = travel.Travel(ship1);
        TravelResults result2 = travel.Travel(ship2);
        TravelResults result3 = travel.Travel(ship3);
        Assert.Equal(typeof(EnvironmentResults.DestroyShip), result1.GetType());
        Assert.Equal(typeof(TravelResults.Success), result2.GetType());
        Assert.Equal(typeof(TravelResults.Success), result3.GetType());
    }

    [Fact]
    public void ShortRouteInSpace_ShuttleAndVaklas_ChooseShuttle()
    {
        var shuttle = new Shuttle();
        var valkas = new Vaklas(new Deflector1());
        var fuelExchange = new FuelExchange(10, 20);
        var space = new Space(
            30,
            new Collection<ISpaceObstacle>());
        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { space }));
        var chooseShip = new ChooserBestShip(
            travel,
            new Collection<Ship>(new List<Ship> { shuttle, valkas }),
            fuelExchange);
        Ship? ship = chooseShip.FindBestShip();
        Assert.Same(typeof(Shuttle), ship?.GetType());
    }

    [Fact]
    public void MiddleRouteInIncreasedNebula_AvgurAndStella_ChooseStella()
    {
        var avgur = new Avgur(new Deflector3());
        var stella = new Stella(new Deflector1());
        var increasedNebula = new IncreasedNebula(
            20,
            new Collection<IIncreasedNebulaObstacle>());
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { increasedNebula }));
        var chooseShip = new ChooserBestShip(
            travel,
            new Collection<Ship>(new List<Ship> { avgur, stella }),
            fuelExchange);
        Ship? ship = chooseShip.FindBestShip();
        Assert.Equal(typeof(Stella), ship?.GetType());
    }

    [Fact]
    public void
        RouteWithNitrineNebula_SpaceWithAsteroidMeteorite_IncreasedNebulaWithTwoAntimatter_ValkasWithPhotonDeflector_ResultIsSuccess()
    {
        var valkas = new Vaklas(new PhotonDeflector(new Deflector1()));
        var nitrineNebula = new NitrineNebula(
            20,
            new Collection<INitrineNebulaObstacle>());
        var space = new Space(
            20,
            new Collection<ISpaceObstacle>(new ISpaceObstacle[] { new Asteroid(), new Meteorite() }));

        var increasedNebula = new IncreasedNebula(
            20,
            new Collection<IIncreasedNebulaObstacle>() { new AntimatterFlash() });

        var fuelExchange = new FuelExchange(10, 20);

        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { nitrineNebula, space, increasedNebula }));
        TravelResults result = travel.Travel(valkas);
        Assert.Equal(typeof(TravelResults.Success), result.GetType());
    }

    [Fact]
    public void RouteInNitrineNebula_ShuttleAndValkas_ChooseVaklas()
    {
        var shuttle = new Shuttle();
        var valkas = new Vaklas(new Deflector1());
        var nitrineNebula = new NitrineNebula(
            300,
            new Collection<INitrineNebulaObstacle>());
        var fuelExchange = new FuelExchange(10, 20);
        var travel = new TravelWay(
            fuelExchange,
            new ReadOnlyCollection<IEnvironment>(new List<IEnvironment> { nitrineNebula }));
        var chooseShip = new ChooserBestShip(
            travel,
            new Collection<Ship>(new List<Ship> { shuttle, valkas }),
            fuelExchange);
        Ship? ship = chooseShip.FindBestShip();
        Assert.Same(typeof(Vaklas), ship?.GetType());
    }
}