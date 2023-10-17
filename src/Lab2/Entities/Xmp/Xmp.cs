namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public class Xmp : IXmp
{
    private readonly string _timings;
    private readonly int _voltage;
    private readonly int _frequency;

    public Xmp(string timings, int voltage, int frequency)
    {
        _timings = timings;
        _voltage = voltage;
        _frequency = frequency;
    }

    public IXmpBuilder Director(IXmpBuilder builder)
    {
        builder
            .WithTimings(_timings)
            .WithVoltage(_voltage)
            .WithFrequency(_frequency);

        return builder;
    }
}