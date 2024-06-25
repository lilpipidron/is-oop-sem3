using Contracts.BankAccounts;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;
    private readonly ICurrentUserService _currentUser;

    public CreateAccountScenario(IBankAccountService bankAccountService, ICurrentUserService currentUser)
    {
        _bankAccountService = bankAccountService;
        _currentUser = currentUser;
    }

    public string Name => "Create Account";

    public void Run()
    {
        if (_currentUser.User is null)
            return;

        _bankAccountService.CreateAccount(_currentUser.User.Id);
        AnsiConsole.WriteLine("Success");
        AnsiConsole.Ask<string>(" ");
    }
}