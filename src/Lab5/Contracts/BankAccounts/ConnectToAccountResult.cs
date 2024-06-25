namespace Contracts.BankAccounts;

public record ConnectToAccountResult
{
    public sealed record Success : ConnectToAccountResult;

    public sealed record ThisAccountDoesntExists : ConnectToAccountResult;
}