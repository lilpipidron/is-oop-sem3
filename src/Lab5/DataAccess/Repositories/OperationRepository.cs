using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Operations;
using Npgsql;

namespace DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> FindByAccountId(long accountId)
    {
        const string sql = """
                           select *
                           from operations
                           where account_id = :accountId;
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        var operationList = new List<Operation>();
        while (reader.Read())
        {
            operationList.Add(
                new Operation(
                    Id: reader.GetInt64(0),
                    AccountId: reader.GetInt64(1),
                    Type: reader.GetFieldValue<OperationType>(2),
                    Amount: reader.GetDecimal(3)));
        }

        return operationList;
    }

    public void Withdrawal(long accountId, decimal amount)
    {
        const string sql = """
                           insert into operations(account_id, operation_type, amount)
                           values(:accountId, CAST(:withdrawal as operation_type), CAST(:amount as money));
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);

        command.AddParameter("accountId", accountId);
        command.AddParameter("withdrawal", OperationType.Withdrawal);
        command.AddParameter("amount", amount);
        command.ExecuteNonQuery();
    }

    public void Replenishment(long accountId, decimal amount)
    {
        const string sql = """
                           insert into operations(account_id, operation_type, amount)
                           values(:accountId, CAST(:replenishment as operation_type), CAST(:amount as money));
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);
        command.AddParameter("replenishment", OperationType.Replenishment);
        command.AddParameter("amount", -amount);

        command.ExecuteNonQuery();
    }
}