using Sugar.Application.Abstractions.Repositories;
using Sugar.Application.Models.Users;

namespace ClassLibrary1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;
    
    public NoteRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }
    public User? AddUser(string login, string password, string name, DateTime birthday, Gender gender, int weight,
        int carbohydrateRatio, int breadUnit)
    {
        const string sql = """
                           select *
                           from users
                           where login = :login
                           and password = :password
                           """;
        
        var connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection)
            .AddParametr(login)
            .AddParametr(password);
        
        using var reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;
        
    }

    public void DeleteUserById(long id)
    {
        throw new NotImplementedException();
    }

    public User FindUserByLogin(string login)
    {
        throw new NotImplementedException();
    }

    public bool ChangeName(string login, string newName)
    {
        throw new NotImplementedException();
    }

    public bool ChangeBirthday(string login, DateTime newBirthday)
    {
        throw new NotImplementedException();
    }

    public bool ChangeGender(string login, Gender newGender)
    {
        throw new NotImplementedException();
    }

    public bool ChangeWeight(string login, int newWeight)
    {
        throw new NotImplementedException();
    }

    public bool ChangeCarbohydrateRatio(string login, int newCarbohydrateRatio)
    {
        throw new NotImplementedException();
    }

    public bool ChangeBreadUnit(string login, int newBreadUnit)
    {
        throw new NotImplementedException();
    }

    public void RegisterNewUser(string username, string password)
    {
        const string sql = """
                            insert into users (username,user_role, password)
                            values (:username,CAST(:user as user_role),:password)
                            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        command.AddParameter("user", UserRole.User);
        command.AddParameter("password", password);

        command.ExecuteNonQuery();
    }
}