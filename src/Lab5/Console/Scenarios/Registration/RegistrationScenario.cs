using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Registration;

public class RegistrationScenario : IScenario
{
    private readonly IUserService _userService;

    public RegistrationScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Registration";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter new username");
        string password = AnsiConsole.Ask<string>("Enter password");

        RegisterResult result = _userService.Register(username, password);

        string message = result switch
        {
           RegisterResult.Success => "Successful register",
           RegisterResult.UserAlreadyExists=> "User already exists",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>(" ");
    }
}