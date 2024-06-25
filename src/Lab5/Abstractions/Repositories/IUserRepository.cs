using Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    User? FindByUserName(string username);
    void RegisterNewUser(string username, string password);
}