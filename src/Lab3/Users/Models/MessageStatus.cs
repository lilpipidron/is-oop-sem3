namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public record MessageStatus
{
    private MessageStatus()
    {
    }

    public sealed record StatusRead() : MessageStatus;

    public sealed record StatusUnread() : MessageStatus;
}