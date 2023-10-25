using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class ChooserBestShip
{
    private readonly Collection<Ship> _ships;
    private readonly TravelWay _travelWay;
    private readonly FuelExchange.FuelExchange _fuelExchange;

    public ChooserBestShip(TravelWay travelWay, Collection<Ship> ships, FuelExchange.FuelExchange fuelExchange)
    {
        _ships = ships;
        _travelWay = travelWay;
        _fuelExchange = fuelExchange;
    }

    public Ship? FindBestShip()
    {
        var chooserSuccessShips = new ChooserSuccessShips(_ships, _travelWay);
        IReadOnlyCollection<Ship> successShips = chooserSuccessShips.Choose();

        var chooserSuccessResults = new ChooserSuccessResults(successShips, _travelWay);
        IReadOnlyCollection<TravelResults> successResults = chooserSuccessResults.Сhoose();

        var chooserProfitableShip = new ChooserProfitableShip(successShips, successResults, _fuelExchange);
        Ship? bestShip = chooserProfitableShip.Choose();

        return bestShip;
    }
}