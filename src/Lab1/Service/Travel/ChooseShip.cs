using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class ChooseShip
{
    private readonly List<Ship> _allShips;
    private readonly TravelWay _travelWay;

    public ChooseShip(TravelWay travelWay)
    {
        _allShips = new List<Ship>();
        _travelWay = travelWay;
    }

    public void AddShip(Ship ship)
    {
        _allShips.Add(ship);
    }

    public Ship? ChooseBest()
    {
        Ship? topShip = null;
        double minCost = -1;
        double minTime = -1;
        foreach (Ship ship in _allShips)
        {
            Result.Result result = _travelWay.Travel(ship);
            if (result is Success success && ((success.FlyCost < minCost || minCost == -1) || (success.FlyCost == minCost && (success.FlyTime < minTime || minTime == -1))))
            {
                minCost = success.FlyCost;
                minTime = success.FlyTime;
                topShip = ship;
            }
        }

        return topShip;
    }
}