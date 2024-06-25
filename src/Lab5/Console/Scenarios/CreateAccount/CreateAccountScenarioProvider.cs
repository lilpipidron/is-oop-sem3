using System.Diagnostics.CodeAnalysis;
using Contracts.BankAccounts;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentAccount;
    private readonly ICurrentUserService _currentUser;

    public CreateAccountScenarioProvider(
        IBankAccountService service,
        ICurrentBankAccountService currentAccount,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentAccount = currentAccount;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.BankAccount is not null || _currentUser.User?.Role is not UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_service, _currentUser);
        return true;
    }
}