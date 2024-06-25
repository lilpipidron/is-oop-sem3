using Abstractions.Repositories;
using Contracts.Operations;
using Models.Operations;

namespace Application.Operations;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _repository;

    public OperationService(IOperationRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Operation> GetAllOperations(long bankAccountId)
    {
        return _repository.FindByAccountId(bankAccountId);
    }

    public void Replenishment(long accountId, decimal amount)
    {
        _repository.Replenishment(accountId, amount);
    }

    public void Withdrawal(long accountId, decimal amount)
    {
        _repository.Withdrawal(accountId, amount);
    }
}