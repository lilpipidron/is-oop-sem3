using System.Globalization;
using Contracts.BankAccounts;
using Spectre.Console;

namespace Console.Scenarios.GetBalance;

public class GetBalanceScenario : IScenario
{
    private readonly IBankAccountService _bankAccountService;
    private readonly ICurrentBankAccountService _currentBankAccount;
    public GetBalanceScenario(IBankAccountService bankAccountService, ICurrentBankAccountService currentBankAccount)
    {
        _bankAccountService = bankAccountService;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Get balance";

    public void Run()
    {
        if (_currentBankAccount.BankAccount is null)
            return;
        AnsiConsole.WriteLine(
            CultureInfo.InvariantCulture,
            _bankAccountService.GetBalance(_currentBankAccount.BankAccount.Id));
        AnsiConsole.Ask<string>(" ");
    }
}