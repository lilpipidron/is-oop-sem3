using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class ChooserProfitableShip
{
    private readonly IReadOnlyCollection<Ship> _successShips;
    private readonly IReadOnlyCollection<TravelResults> _successResults;
    private readonly IFuelExchange _fuelExchange;

    public ChooserProfitableShip(IReadOnlyCollection<Ship> successShips, IReadOnlyCollection<TravelResults> successResults, IFuelExchange fuelExchange)
    {
        _successShips = successShips;
        _successResults = successResults;
        _fuelExchange = fuelExchange;
    }

    public Ship? Choose()
    {
        Ship? profitShip = null;
        double minCost = -1;
        double minTime = -1;
        for (int i = 0; i < _successResults.Count; i++)
        {
            if (_successResults.ElementAt(i) is not TravelResults.Success success) continue;
            double cost = _fuelExchange.TotalCost(success.Fuel);
            double time = success.Time.Sum();
            if (minCost == -1 || minCost > cost || ((minTime == -1 || minTime > time) && minCost == cost))
            {
                minCost = cost;
                minTime = time;
                profitShip = _successShips.ElementAt(i);
            }
        }

        return profitShip;
    }
}