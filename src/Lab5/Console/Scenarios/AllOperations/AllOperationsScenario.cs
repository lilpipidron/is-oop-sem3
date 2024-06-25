using Contracts.BankAccounts;
using Contracts.Operations;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.AllOperations;

public class AllOperationsScenario : IScenario
{
    private readonly IOperationService _operationService;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public AllOperationsScenario(IOperationService operationService, ICurrentBankAccountService currentBankAccount)
    {
        _operationService = operationService;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Get all operations";

    public void Run()
    {
        if (_currentBankAccount.BankAccount is null)
            return;
        IEnumerable<Operation> operations = _operationService.GetAllOperations(_currentBankAccount.BankAccount.Id);
        foreach (Operation operation in operations)
        {
            AnsiConsole.WriteLine($"id:{operation.Id},type: {operation.Type},amount:{operation.Amount}");
        }

        AnsiConsole.Ask<string>(" ");
    }
}