namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;

public interface IJedecBuilder
{
    IJedecBuilder WithTimings(string timings);

    IJedecBuilder WithVoltage(int voltage);

    IJedecBuilder WithFrequency(int frequency);

    IJedec Build();
}