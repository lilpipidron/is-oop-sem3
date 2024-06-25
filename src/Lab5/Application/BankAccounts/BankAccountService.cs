using Abstractions.Repositories;
using Contracts.BankAccounts;
using Contracts.Operations;
using Models.BankAccounts;

namespace Application.BankAccounts;

internal class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _repository;
    private readonly CurrentBankAccountManager _currentBankAccountManager;

    public BankAccountService(IBankAccountRepository repository, CurrentBankAccountManager currentBankAccount)
    {
        _repository = repository;
        _currentBankAccountManager = currentBankAccount;
    }

    public IEnumerable<BankAccount> GetAccountsByUserId(long userId)
    {
        return _repository.FindByUserId(userId);
    }

    public ConnectToAccountResult ConnectToBankAccount(long userId, long accountId)
    {
        BankAccount? bankAccount = _repository.FindByUserIdAndAccountId(userId, accountId);

        if (bankAccount is null)
            return new ConnectToAccountResult.ThisAccountDoesntExists();

        _currentBankAccountManager.BankAccount = bankAccount;

        return new ConnectToAccountResult.Success();
    }

    public void CreateAccount(long userId)
    {
        _repository.CreateNewBankAccount(userId);
    }

    public decimal GetBalance(long accountId)
    {
        return _repository.GetBalance(accountId);
    }

    public OperationResult TryChangeBalance(long accountId, decimal amount)
    {
        return _repository.TryChangeBalance(accountId, amount);
    }
}