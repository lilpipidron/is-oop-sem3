namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;

public class Psu : IPsu
{
    private readonly int _peakLoad;

    public Psu(int peakLoad)
    {
        _peakLoad = peakLoad;
    }
}