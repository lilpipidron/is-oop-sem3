using Console.Scenarios.AllOperations;
using Console.Scenarios.ChooseAccount;
using Console.Scenarios.CreateAccount;
using Console.Scenarios.GetBalance;
using Console.Scenarios.LoginAdmin;
using Console.Scenarios.LoginUser;
using Console.Scenarios.Registration;
using Console.Scenarios.Replenishment;
using Console.Scenarios.Withdrawal;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminRoleScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChooseAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawalScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ReplenishmentScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AllOperationsScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();

        return collection;
    }
}