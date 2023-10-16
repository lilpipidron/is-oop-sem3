namespace Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;

public record RamFormFactor
{
    private RamFormFactor()
    {
    }

    public sealed record Dimm : RamFormFactor;

    public sealed record SoDimm : RamFormFactor;

    public sealed record Rimm : RamFormFactor;
}