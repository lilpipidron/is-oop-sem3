using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.LoginUser;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "LoginUser";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");

        LoginResult result = _userService.Login(username, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            LoginResult.IncorrectPassword => "Incorrect Password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>(" ");
    }
}