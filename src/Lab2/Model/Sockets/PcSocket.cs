namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

public record PcSocket
{
    private PcSocket()
    {
    }

    public sealed record LGA1576() : PcSocket;

    public sealed record LGA1156() : PcSocket;

    public sealed record AM2() : PcSocket;

    public sealed record AM3() : PcSocket;
}