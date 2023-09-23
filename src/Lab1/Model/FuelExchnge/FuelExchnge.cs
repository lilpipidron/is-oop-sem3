using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Model.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Model.FuelExchnge;

public class FuelExchnge
{
    public FuelExchnge(double simpleFuelCost, double specialFuelCost)
    {
        SimpleFuelCost = simpleFuelCost;
        SpecialFuelCost = specialFuelCost;
    }

    private double SimpleFuelCost { get; }

    private double SpecialFuelCost { get; }

    public double TotalCost(Fuel fuel)
    {
        switch (fuel)
        {
         case null:
             throw new ArgumentNullException(nameof(fuel));
         case SimpleFuel:
             return SimpleFuelCost * fuel.Amount;
         case SpecialFuel:
             return SpecialFuelCost * fuel.Amount;
         default:
             throw new ArgumentException("We have no information about this type of fuel");
        }
    }
}