using System.Diagnostics.CodeAnalysis;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.Registration;

public class RegistrationScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public RegistrationScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User?.Role is not UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new RegistrationScenario(_service);
        return true;
    }
}