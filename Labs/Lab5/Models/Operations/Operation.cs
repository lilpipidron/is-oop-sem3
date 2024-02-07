namespace Models.Operations;

public record Operation(long Id, long AccountId, OperationType Type, decimal Amount);