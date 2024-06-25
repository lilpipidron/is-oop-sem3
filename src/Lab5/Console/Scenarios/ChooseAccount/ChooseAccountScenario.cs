using System.Globalization;
using Contracts.BankAccounts;
using Contracts.Users;
using Models.BankAccounts;
using Spectre.Console;

namespace Console.Scenarios.ChooseAccount;

public class ChooseAccountScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;
    private readonly ICurrentUserService _currentUser;

    public ChooseAccountScenario(IBankAccountService bankAccountService, ICurrentUserService currentUser)
    {
        _bankAccountService = bankAccountService;
        _currentUser = currentUser;
    }

    public string Name => "Choose Account";

    public void Run()
    {
        if (_currentUser.User is null)
            return;

        IEnumerable<BankAccount> accounts = _bankAccountService.GetAccountsByUserId(_currentUser.User.Id);
        foreach (BankAccount account in accounts)
        {
            AnsiConsole.WriteLine(CultureInfo.InvariantCulture, account.Id);
        }

        long accountId = AnsiConsole.Ask<long>("Choose account");

        ConnectToAccountResult result = _bankAccountService.ConnectToBankAccount(
            _currentUser.User.Id,
            accountId);

        string message = result switch
        {
            ConnectToAccountResult.Success => "Successful connect",
            ConnectToAccountResult.ThisAccountDoesntExists => "This account doesn't exist",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>(" ");
    }
}