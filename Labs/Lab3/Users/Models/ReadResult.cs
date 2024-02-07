namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public abstract record ReadResult
{
    private ReadResult()
    {
    }

    public sealed record ReadSuccess : ReadResult;

    public sealed record ReadFailed : ReadResult;
}