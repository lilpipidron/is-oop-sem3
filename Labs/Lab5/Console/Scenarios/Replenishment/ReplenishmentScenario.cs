using Contracts.BankAccounts;
using Contracts.Operations;
using Spectre.Console;

namespace Console.Scenarios.Replenishment;

public class ReplenishmentScenario : IScenario
{
    private readonly IOperationService _operationService;
    private readonly ICurrentBankAccountService _currentBankAccount;
    private readonly IBankAccountService _bankAccountService;

    public ReplenishmentScenario(IOperationService operationService, ICurrentBankAccountService currentBankAccount, IBankAccountService bankAccountService)
    {
        _operationService = operationService;
        _currentBankAccount = currentBankAccount;
        _bankAccountService = bankAccountService;
    }

    public string Name => "Replenishment";

    public void Run()
    {
        if (_currentBankAccount.BankAccount is null)
            return;
        decimal amount = AnsiConsole.Ask<decimal>("How much money to deposit into the account?");
        _bankAccountService.TryChangeBalance(_currentBankAccount.BankAccount.Id, amount);
        _operationService.Replenishment(_currentBankAccount.BankAccount.Id, amount);
        AnsiConsole.WriteLine("Successful");
        AnsiConsole.Ask<string>(" ");
    }
}