using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.LoginAdmin;

public class AdminRoleScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public AdminRoleScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminRoleScenario(_service);
        return true;
    }
}