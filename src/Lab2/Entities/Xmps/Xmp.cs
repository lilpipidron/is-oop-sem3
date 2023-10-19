namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

public class Xmp : IXmp
{
    public Xmp(string name, string timings, int voltage, int frequency)
    {
        Name = name;
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Name { get; }
    public string Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public IXmpBuilder Director(IXmpBuilder builder)
    {
        builder
            .WithName(Name)
            .WithTimings(Timings)
            .WithVoltage(Voltage)
            .WithFrequency(Frequency);

        return builder;
    }
}