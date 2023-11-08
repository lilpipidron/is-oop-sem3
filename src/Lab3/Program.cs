using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseMessengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3;

internal class Program
{
    private static void Main()
    {
        var message = new Message("233", "12qedqe", 2);
        var m = new Messenger();
        var adresse = new ProxyAddressee(new AdresseeMessenger(m), 1);
        adresse.TransferMessage(message);
    }
}