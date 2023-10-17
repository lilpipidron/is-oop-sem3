namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public interface IXmpBuilder
{
    IXmpBuilder WithTimings(string timings);

    IXmpBuilder WithVoltage(int voltage);

    IXmpBuilder WithFrequency(int frequency);

    IXmp Build();
}