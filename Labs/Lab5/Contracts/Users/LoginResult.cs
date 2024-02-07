namespace Contracts.Users;

public record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record IncorrectPassword : LoginResult;
    public sealed record NotFound : LoginResult;
}