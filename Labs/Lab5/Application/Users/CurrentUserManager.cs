using Contracts.Users;
using Models.Users;

namespace Application.Users;

internal class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}