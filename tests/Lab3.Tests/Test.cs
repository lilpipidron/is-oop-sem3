using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseMessengers;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseUsers;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Test
{
    [Fact]
    public void UserGetMessage_ShouldSaveLikeUnread_WhenUserReceiveMessage()
    {
        var message = new Message("Title", "Body", 2);
        var user = new User();
        var adressee = new ProxyFilterAddressee(new AddreseeUser(user), 1);
        adressee.TransferMessage(message);
        MessageStatus? status = user.FindMessage(message);
        Assert.Equal(new MessageStatus.StatusUnread(), status);
    }

    [Fact]
    public void UserReadMessage_ShouldChangeStatusOnRead_WhenMessageIsUnread()
    {
        var message = new Message("Title", "Body", 2);
        var user = new User();
        var adressee = new ProxyFilterAddressee(new AddreseeUser(user), 1);
        adressee.TransferMessage(message);
        user.ReadMessage(message);
        MessageStatus? status = user.FindMessage(message);
        Assert.Equal(new MessageStatus.StatusRead(), status);
    }

    [Fact]
    public void UserReadMessage_ShouldGiveFailedResult_WhenMessageIsRead()
    {
        var message = new Message("Title", "Body", 2);
        var user = new User();
        var adressee = new ProxyFilterAddressee(new AddreseeUser(user), 1);
        adressee.TransferMessage(message);
        user.ReadMessage(message);
        ReadResult res = user.ReadMessage(message);
        Assert.Equal(new ReadResult.ReadFailed(), res);
    }

    [Fact]
    public void SendMessage_ShouldBeIgnored_WhenPriorityIsHigh()
    {
        var message = new Message("Title", "Body", 2);
        IUser? user = Substitute.For<IUser>();
        var addressee = new ProxyFilterAddressee(new AddreseeUser(user), 5);
        addressee.TransferMessage(message);
        user.DidNotReceive().ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void ForwardMessage_ShouldWriteLogInFile_WhenLoggingIsEnable()
    {
        var message = new Message("Title", "Body", 2);
        var user = new User();
        ILogger? logger = Substitute.For<ILogger>();
        var adressee = new ProxyFilterAddressee(new AddresseesLogger(new AddreseeUser(user), logger), 1);
        adressee.TransferMessage(message);
        logger.Received().Log(Arg.Any<string>());
    }

    [Fact]
    public void ForwardMessage_ShouldWriteMessageInConsole_WhenAddresseIsMessenger()
    {
        var message = new Message("Title", "Body", 2);
        IMessenger? messenger = Substitute.For<IMessenger>();
        var addressee = new ProxyFilterAddressee(new AdresseeMessenger(messenger), 2);
        addressee.TransferMessage(message);
        messenger.Received().PrintMessage(Arg.Any<string>());
    }
}