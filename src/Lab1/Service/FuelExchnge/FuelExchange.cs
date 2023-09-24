using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.FuelExchnge;

public class FuelExchange
{
    public FuelExchange(double simpleFuelCost, double specialFuelCost)
    {
        SimpleFuelCost = simpleFuelCost;
        SpecialFuelCost = specialFuelCost;
    }

    private double SimpleFuelCost { get; }

    private double SpecialFuelCost { get; }

    public double TotalCost(Fuel fuel) => fuel switch
    {
        null => throw new ArgumentNullException(nameof(fuel)),
        SimpleFuel simpleFuel => SimpleFuelCost * simpleFuel.Amount,
        SpecialFuel specialFuel => SpecialFuelCost * specialFuel.Amount,
        _ => throw new ArgumentException("We have no information about this type of fuel"),
    };
}