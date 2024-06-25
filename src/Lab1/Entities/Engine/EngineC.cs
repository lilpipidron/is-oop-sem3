using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : IEngine, IEngineWithSpeedDown
{
    private const double Speed = 20;
    private const int StartCost = 50;

    private double Time { get; set; }

    public EngineTravelResult Travel(int distance)
    {
        Time = distance / Speed;
        var fuel = new SimpleFuel(distance + StartCost);
        return new EngineTravelResult.TravelSuccess(Time, fuel);
    }

    public EngineTravelResult TravelWithSpeedDown(int distance)
    {
        double endSpeed = double.Pow(Speed, 2) - (2 * distance * (0.1 * Speed));
        if (endSpeed <= 0)
        {
            return new EngineTravelResult.TravelFailed();
        }

        Time = (Speed - double.Sqrt(endSpeed)) / (0.1 * Speed);

        return new EngineTravelResult.TravelSuccess(Time, new SimpleFuel(Time));
    }
}