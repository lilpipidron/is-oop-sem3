namespace Contracts.Operations;

public record OperationResult
{
    private OperationResult()
    {
    }

    public sealed record Success : OperationResult;

    public sealed record NotEnoughMoney : OperationResult;
}