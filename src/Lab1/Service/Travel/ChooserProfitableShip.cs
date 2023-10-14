using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public static class ChooserProfitableShip
{
    public static Ship? ChooseProfitShip(Collection<Ship> successShips, Collection<Result> successResults, IFuelExchange fuelExchange)
    {
        Ship? profitShip = null;
        double minCost = -1;
        double minTime = -1;
        for (int i = 0; i < successResults.Count; i++)
        {
            if (successResults[i] is not Result.Success success) continue;
            double cost = fuelExchange.TotalCost(success.Fuel);
            double time = success.Time.Sum();
            if ((minCost == -1 || minCost > cost) || (((minTime == -1) || (minTime > time)) && (minCost == cost)))
            {
                minCost = cost;
                minTime = time;
                profitShip = successShips[i];
            }
        }

        return profitShip;
    }
}