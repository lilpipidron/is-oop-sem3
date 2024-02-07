namespace Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, string password);
    RegisterResult Register(string username, string password);
}