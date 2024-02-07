using Application.BankAccounts;
using Application.Operations;
using Application.Users;
using Contracts.BankAccounts;
using Contracts.Operations;
using Contracts.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IBankAccountService, BankAccountService>();
        collection.AddScoped<IOperationService, OperationService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        collection.AddScoped<CurrentBankAccountManager>();
        collection.AddScoped<ICurrentBankAccountService>(
            p => p.GetRequiredService<CurrentBankAccountManager>());
        return collection;
    }
}