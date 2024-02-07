using Contracts.Users;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace Console.Scenarios.LoginAdmin;

public class AdminRoleScenario : IScenario
{
    private readonly IConfigurationRoot _adminPassword;
    private readonly IUserService _userService;

    public AdminRoleScenario(IUserService userService)
    {
        _userService = userService;
        _adminPassword = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();
    }

    public string Name => "LoginAdmin";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter admin password");
        if (password != _adminPassword["AdminPassword"])
        {
            Environment.Exit(239);
        }

        _userService.Login("Admin", "Admin");
        AnsiConsole.WriteLine("Successful login");
        AnsiConsole.Ask<string>(" ");
    }
}