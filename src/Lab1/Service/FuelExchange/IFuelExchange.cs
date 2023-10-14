using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public interface IFuelExchange
{
    public double TotalCost(Collection<IFuel> allFuel);
}