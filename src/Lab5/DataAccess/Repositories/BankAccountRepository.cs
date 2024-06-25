using Abstractions.Repositories;
using Contracts.Operations;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.BankAccounts;
using Npgsql;

namespace DataAccess.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<BankAccount> FindByUserId(long userId)
    {
        const string sql = """
                            select *
                            from bank_accounts
                            where user_id = :userId;
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("userid", userId);
        using NpgsqlDataReader reader = command.ExecuteReader();
        var accounts = new List<BankAccount>();
        while (reader.Read())
        {
            accounts.Add(new BankAccount(
                Id: reader.GetInt64(0),
                UserId: reader.GetInt64(1),
                Amount: reader.GetDecimal(2)));
        }

        return accounts;
    }

    public BankAccount? FindByUserIdAndAccountId(long userId, long accountId)
    {
        const string sql = """
                            select *
                            from bank_accounts
                            where user_id = :userId
                            and account_id = :accountId;
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userid", userId);
        command.AddParameter("accountid", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read() is false)
            return null;
        return new BankAccount(
            Id: reader.GetInt64(0),
            UserId: reader.GetInt64(1),
            Amount: reader.GetDecimal(2));
    }

    public void CreateNewBankAccount(long userId)
    {
        const string sql = """
                           insert into bank_accounts (user_id, balance)
                           values(:userId, 0)
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("userid", userId);
        command.AddParameter("balance", 0);

        command.ExecuteNonQuery();
    }

    public decimal GetBalance(long accountId)
    {
        const string sql = """
                           select balance
                           from bank_accounts
                           where account_id = :accountId;
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountid", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return reader.GetDecimal(0);
    }

    public OperationResult TryChangeBalance(long accountId, decimal amount)
    {
        decimal balance = GetBalance(accountId);
        if (balance + amount < 0)
            return new OperationResult.NotEnoughMoney();
        const string sql = """
                           update bank_accounts
                           set balance = balance + CAST(:amount as money)
                           where account_id = :accountId;
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountid", accountId);
        command.AddParameter("amount", amount);

        command.ExecuteNonQuery();
        return new OperationResult.Success();
    }
}