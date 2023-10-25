using Itmo.ObjectOrientedProgramming.Lab1.Model.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Model.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineE : IEngine, IEngineWithSpeedDown
{
    private const int StartCost = 50;
    private double Time { get; set; }

    public EngineTravelResult Travel(int distance)
    {
        double time = double.Log(distance + 1);
        Time = time;
        var fuel = new SimpleFuel(distance + StartCost);
        return new EngineTravelResult.TravelSuccess(Time, fuel);
    }

    public EngineTravelResult TravelWithSpeedDown(int distance)
    {
        double speed = double.Exp(distance);
        double endSpeed = double.Pow(speed, 2) - (2 * distance * (0.1 * speed));
        if (endSpeed <= 0)
        {
            return new EngineTravelResult.TravelFailed();
        }

        Time = (speed - double.Sqrt(endSpeed)) / (0.1 * speed);

        return new EngineTravelResult.TravelSuccess(Time, new SimpleFuel(Time));
    }
}