using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class ChooserSuccessShips : IChooser
{
    private readonly IReadOnlyCollection<Ship> _ships;
    private readonly TravelWay _travelWay;

    public ChooserSuccessShips(IReadOnlyCollection<Ship> ships, TravelWay travelWay)
    {
        _ships = ships;
        _travelWay = travelWay;
    }

    public IReadOnlyCollection<Ship> Choose()
    {
        var successShips = new Collection<Ship>();
        foreach (Ship ship in _ships)
        {
            TravelResults travelResult = _travelWay.Travel(ship);
            if (travelResult is TravelResults.Success)
            {
                successShips.Add(ship);
            }
        }

        return successShips;
    }
}