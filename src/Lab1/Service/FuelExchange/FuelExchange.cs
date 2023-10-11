using System;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public class FuelExchange
{
    private readonly double _simpleFuelCost;
    private readonly double _specialFuelCost;

    public FuelExchange(double simpleFuelCost, double specialFuelCost)
    {
        _simpleFuelCost = simpleFuelCost;
        _specialFuelCost = specialFuelCost;
    }

    public double TotalCost(IFuel fuel) => fuel switch
    {
        null => throw new ArgumentNullException(nameof(fuel)),
        SimpleFuel simpleFuel => _simpleFuelCost * simpleFuel.Amount,
        SpecialFuel specialFuel => _specialFuelCost * specialFuel.Amount,
        _ => throw new ArgumentException("We have no information about this type of fuel"),
    };
}