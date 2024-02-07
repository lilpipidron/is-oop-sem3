namespace Models.Users;

public record User(long Id, string Username, UserRole Role, string Password);