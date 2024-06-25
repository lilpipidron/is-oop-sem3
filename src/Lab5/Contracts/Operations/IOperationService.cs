using Models.Operations;

namespace Contracts.Operations;

public interface IOperationService
{
    IEnumerable<Operation> GetAllOperations(long bankAccountId);
    void Replenishment(long accountId, decimal amount);

    void Withdrawal(long accountId, decimal amount);
}