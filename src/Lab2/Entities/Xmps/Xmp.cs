namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

public class Xmp : IXmp
{
    public Xmp(string timings, int voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public IXmpBuilder Director(IXmpBuilder builder)
    {
        builder
            .WithTimings(Timings)
            .WithVoltage(Voltage)
            .WithFrequency(Frequency);

        return builder;
    }
}