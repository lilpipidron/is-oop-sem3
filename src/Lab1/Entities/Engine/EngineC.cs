namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class EngineC : Engine
{
    public EngineC()
        : base(20, 20)
    {
    }

    public override void Move(int distance)
    {
        double time = distance / Speed;
        Time += time;
        Fuel.Use(time + StartCost);
    }

    public override bool SpeedDown(int distance)
    {
        for (int i = 0; i < distance; i++)
        {
            Speed *= 0.9;
            Move(1);
        }

        return Speed > 0.1;
    }
}