using Models.BankAccounts;

namespace Contracts.BankAccounts;

public interface ICurrentBankAccountService
{
    BankAccount? BankAccount { get; }
}