using Contracts.BankAccounts;
using Contracts.Operations;
using Spectre.Console;

namespace Console.Scenarios.Withdrawal;

public class WithdrawalScenario : IScenario
{
    private readonly IOperationService _operationService;
    private readonly ICurrentBankAccountService _currentBankAccount;
    private readonly IBankAccountService _bankAccountService;

    public WithdrawalScenario(
        IOperationService operationService,
        ICurrentBankAccountService currentBankAccount,
        IBankAccountService bankAccountService)
    {
        _operationService = operationService;
        _currentBankAccount = currentBankAccount;
        _bankAccountService = bankAccountService;
    }

    public string Name => "Withdrawal";

    public void Run()
    {
        if (_currentBankAccount.BankAccount is null)
            return;

        decimal amount = AnsiConsole.Ask<decimal>("How much to withdraw money from account?");

        OperationResult result = _bankAccountService.TryChangeBalance(_currentBankAccount.BankAccount.Id, -amount);

        if (result is OperationResult.Success)
            _operationService.Withdrawal(_currentBankAccount.BankAccount.Id, amount);
        string message = result switch
        {
            OperationResult.Success => "Successful withdrawal",
            OperationResult.NotEnoughMoney => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>(" ");
    }
}