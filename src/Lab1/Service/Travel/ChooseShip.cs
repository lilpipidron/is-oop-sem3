using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class ChooseShip
{
    public ChooseShip(TravelWay travelWay)
    {
        AllShips = new List<Ship>();
        TravelWay = travelWay;
    }

    private List<Ship> AllShips { get; set; }
    private TravelWay TravelWay { get; set; }

    public void AddShip(Ship ship)
    {
        AllShips.Add(ship);
    }

    public Ship? ChooseBest()
    {
        Ship? topShip = null;
        double minCost = -1;
        foreach (Ship ship in AllShips)
        {
            Result result = TravelWay.Travel(ship);
            if (result is Success success)
            {
                if (success.FlyCost < minCost || minCost == -1)
                {
                    minCost = success.FlyCost;
                    topShip = ship;
                }
            }
        }

        return topShip;
    }
}