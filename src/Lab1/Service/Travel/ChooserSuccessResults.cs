using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public class ChooserSuccessResults : IChooser
{
    private readonly IEnumerable<Ship> _ships;
    private readonly TravelWay _travelWay;

    public ChooserSuccessResults(IEnumerable<Ship> ships, TravelWay travelWay)
    {
        _ships = ships;
        _travelWay = travelWay;
    }

    public IReadOnlyCollection<TravelResults> Сhoose()
    {
        var successResults = new Collection<TravelResults>();
        foreach (Ship ship in _ships)
        {
            successResults.Add(_travelWay.Travel(ship));
        }

        return successResults;
    }
}