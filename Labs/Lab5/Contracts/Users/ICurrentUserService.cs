using Models.Users;

namespace Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}