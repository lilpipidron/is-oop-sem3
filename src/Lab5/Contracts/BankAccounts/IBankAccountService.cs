using Contracts.Operations;
using Models.BankAccounts;

namespace Contracts.BankAccounts;

public interface IBankAccountService
{
    IEnumerable<BankAccount> GetAccountsByUserId(long userId);
    ConnectToAccountResult ConnectToBankAccount(long userId, long accountId);

    void CreateAccount(long userId);

    decimal GetBalance(long accountId);

    OperationResult TryChangeBalance(long accountId, decimal amount);
}