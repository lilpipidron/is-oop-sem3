namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public abstract record PrintResult
{
    private PrintResult()
    {
    }

    public sealed record PrintSuccess : PrintResult;

    public sealed record PrintFailed : PrintResult;
}