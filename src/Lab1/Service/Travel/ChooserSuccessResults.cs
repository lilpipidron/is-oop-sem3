using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Travel;

public static class ChooserSuccessResults
{
    public static Collection<Result> ChooseSeccessResults(IEnumerable<Ship> ships, TravelWay travelWay)
    {
        var successResults = new Collection<Result>();
        foreach (Ship ship in ships)
        {
            successResults.Add(travelWay.Travel(ship));
        }

        return successResults;
    }
}