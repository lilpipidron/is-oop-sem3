using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public static class ChooserSuccessShips
{
    public static Collection<Ship> ChooseSuccessShips(Collection<Ship> ships, TravelWay travelWay)
    {
        var successShips = new Collection<Ship>();
        foreach (Ship ship in ships)
        {
            Result travelResult = travelWay.Travel(ship);
            if (travelResult is Result.Success)
            {
                successShips.Add(ship);
            }
        }

        return successShips;
    }
}