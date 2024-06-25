using System.Diagnostics.CodeAnalysis;
using Contracts.BankAccounts;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.GetBalance;

public class GetBalanceScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentAccount;
    private readonly ICurrentUserService _currentUser;

    public GetBalanceScenarioProvider(
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
        if (_currentAccount.BankAccount is null || _currentUser.User?.Role is not UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new GetBalanceScenario(_service, _currentAccount);
        return true;
    }
}