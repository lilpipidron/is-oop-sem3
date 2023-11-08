using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseUsers;

public class AddreseeUser : IAddressee
{
    private readonly IUser _user;

    public AddreseeUser(IUser user)
    {
        _user = user;
    }

    public void TransferMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }
}