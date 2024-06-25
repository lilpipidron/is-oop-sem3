using Models.Operations;

namespace Abstractions.Repositories;

public interface IOperationRepository
{
    IEnumerable<Operation> FindByAccountId(long accountId);
    void Withdrawal(long accountId, decimal amount);

    void Replenishment(long accountId, decimal amount);
}