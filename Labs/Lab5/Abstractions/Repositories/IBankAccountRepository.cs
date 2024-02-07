using Contracts.Operations;
using Models.BankAccounts;

namespace Abstractions.Repositories;

public interface IBankAccountRepository
{
    IEnumerable<BankAccount> FindByUserId(long userId);
    BankAccount? FindByUserIdAndAccountId(long userId, long accountId);
    void CreateNewBankAccount(long userId);

    decimal GetBalance(long accountId);
    OperationResult TryChangeBalance(long accountId, decimal amount);
}