using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

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
            Model.Result.Result result = _travelWay.Travel(ship);
            if (result is not Result.Success success ||
                (!(success.FlyCost < minCost) && Math.Abs(minCost + 1) != 0 &&
                 (Math.Abs(success.FlyCost - minCost) != 0 ||
                  (!(success.FlyTime < minTime) && Math.Abs(minTime + 1) != 0))))
                continue;
            minCost = success.FlyCost;
            minTime = success.FlyTime;
            topShip = ship;
        }

        return topShip;
    }
}