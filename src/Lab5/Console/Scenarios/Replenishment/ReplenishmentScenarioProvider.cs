using System.Diagnostics.CodeAnalysis;
using Contracts.BankAccounts;
using Contracts.Operations;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.Replenishment;

public class ReplenishmentScenarioProvider : IScenarioProvider
{
    private readonly IOperationService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;
    private readonly ICurrentUserService _currentUser;
    private readonly IBankAccountService _bankAccountService;

    public ReplenishmentScenarioProvider(IOperationService service, ICurrentBankAccountService currentBankAccount, ICurrentUserService currentUser, IBankAccountService bankAccountService)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
        _currentUser = currentUser;
        _bankAccountService = bankAccountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccount.BankAccount is null || _currentUser.User?.Role is not UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new ReplenishmentScenario(_service, _currentBankAccount, _bankAccountService);
        return true;
    }
}