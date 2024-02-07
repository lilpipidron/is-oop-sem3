using Contracts.BankAccounts;
using Models.BankAccounts;

namespace Application.BankAccounts;

internal class CurrentBankAccountManager : ICurrentBankAccountService
{
    public BankAccount? BankAccount { get; set; }
}