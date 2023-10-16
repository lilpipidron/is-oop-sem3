namespace Itmo.ObjectOrientedProgramming.Lab2.Model.SupportedFrequencyVoltagePairs;

public class SupportedFrequencyVoltagePairs : ISupportedFrequencyVoltagePairs
{
    public SupportedFrequencyVoltagePairs(int firstFrequency, int secondFrequency, int voltage)
    {
        FirstFrequency = firstFrequency;
        SecondFrequency = secondFrequency;
        Voltage = voltage;
    }

    public int FirstFrequency { get; }
    public int SecondFrequency { get; }
    public int Voltage { get; }
}