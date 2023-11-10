using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseUsers;

public class AddreseeUser : IAddressee
{
    private readonly IUser _user;

    public AddreseeUser(IUser user)
    {
        _user = user;
    }

    public void TransferMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}