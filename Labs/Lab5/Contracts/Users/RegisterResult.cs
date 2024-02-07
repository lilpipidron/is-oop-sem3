namespace Contracts.Users;

public record RegisterResult
{
    public sealed record Success : RegisterResult;

    public sealed record UserAlreadyExists : RegisterResult;
}