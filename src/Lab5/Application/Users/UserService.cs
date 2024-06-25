using Abstractions.Repositories;
using Contracts.Users;
using Models.Users;

namespace Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username, string password)
    {
        User? user = _repository.FindByUserName(username);

        if (user is null)
            return new LoginResult.NotFound();
        if (user.Password != password)
            return new LoginResult.IncorrectPassword();

        _currentUserManager.User = user;

        return new LoginResult.Success();
    }

    public RegisterResult Register(string username, string password)
    {
        User? user = _repository.FindByUserName(username);
        if (user is not null)
            return new RegisterResult.UserAlreadyExists();

        _repository.RegisterNewUser(username, password);
        return new RegisterResult.Success();
    }
}