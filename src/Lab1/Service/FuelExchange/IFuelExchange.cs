using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public interface IFuelExchange
{
    public double TotalCost(IReadOnlyCollection<IFuel> allFuel);
}