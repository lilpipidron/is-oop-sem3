namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;

public class Jedec : IJedec
{
    internal Jedec(string timings, int voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timings { get; }

    public int Voltage { get; }

    public int Frequency { get; }

    public IJedecBuilder Director(IJedecBuilder builder)
    {
        builder
            .WithTimings(Timings)
            .WithVoltage(Voltage)
            .WithFrequency(Frequency);

        return builder;
    }
}