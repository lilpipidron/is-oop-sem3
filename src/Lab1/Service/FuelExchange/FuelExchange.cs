using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public class FuelExchange : IFuelExchange
{
    private readonly double _simpleFuelCost;
    private readonly double _specialFuelCost;

    public FuelExchange(double simpleFuelCost, double specialFuelCost)
    {
        _simpleFuelCost = simpleFuelCost;
        _specialFuelCost = specialFuelCost;
    }

    public double TotalCost(Collection<IFuel> allFuel)
    {
        return allFuel.Sum(fuel => fuel switch
        {
            SimpleFuel => fuel.Amount * _simpleFuelCost,
            SpecialFuel => fuel.Amount * _specialFuelCost,
            _ => throw new ArgumentException("We have no information about this type of fuel"),
        });
    }
}