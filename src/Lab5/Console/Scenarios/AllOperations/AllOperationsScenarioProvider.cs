using System.Diagnostics.CodeAnalysis;
using Contracts.BankAccounts;
using Contracts.Operations;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.AllOperations;

public class AllOperationsScenarioProvider : IScenarioProvider
{
    private readonly IOperationService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;
    private readonly ICurrentUserService _currentUser;

    public AllOperationsScenarioProvider(IOperationService service, ICurrentBankAccountService currentBankAccount, ICurrentUserService currentUser)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentBankAccount.BankAccount is null || _currentUser.User?.Role is not UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new AllOperationsScenario(_service, _currentBankAccount);
        return true;
    }
}