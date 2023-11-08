using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseUsers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3;

internal class Program
{
    private static void Main()
    {
        var message = new Message("233", "12qedqe", 2);
        var adresse = new ProxyAddressee(new AddreseeUser(new User()), 5);
        adresse.TransferMessage(message);
    }
}