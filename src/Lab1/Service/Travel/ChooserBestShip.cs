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
        Collection<Ship> successShips = ChooserSuccessShips.ChooseSuccessShips(_ships, _travelWay);
        Collection<Result> successResults = ChooserSuccessResults.ChooseSeccessResults(successShips, _travelWay);
        Ship? bestShip = ChooserProfitableShip.ChooseProfitShip(successShips, successResults, _fuelExchange);
        return bestShip;
    }
}