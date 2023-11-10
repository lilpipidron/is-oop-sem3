using System.Collections.Generic;
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
    public void UserGetMessage_SavedLikeUnreaded()
    {
        var message = new Message("233", "12qedqe", 2);
        var user = new User();
        var adressee = new ProxyAddressee(new AddreseeUser(user), 1);
        adressee.TransferMessage(message);
        Assert.Equal(new Dictionary<IMessage, bool> { { new Message("233", "12qedqe", 2), false } }, user.Messages);
    }

    [Fact]
    public void UserTryReadMessage_ChangeStatus()
    {
        var message = new Message("233", "12qedqe", 2);
        var user = new User();
        var adressee = new ProxyAddressee(new AddreseeUser(user), 1);
        adressee.TransferMessage(message);
        user.ReadMessage(message);
        Assert.Equal(new Dictionary<IMessage, bool> { { new Message("233", "12qedqe", 2), true } }, user.Messages);
    }

    [Fact]
    public void TryReadMessageSecondTime_GetFailedResult()
    {
        var message = new Message("233", "12qedqe", 2);
        var user = new User();
        var adressee = new ProxyAddressee(new AddreseeUser(user), 1);
        adressee.TransferMessage(message);
        user.ReadMessage(message);
        ReadResult res = user.ReadMessage(message);
        Assert.Equal(new ReadResult.ReadFailed(), res);
    }

    [Fact]
    public void TryGetMessageWithLowestLvl_TransferDenied()
    {
        var message = new Message("233", "12qedqe", 2);
        IUser? user = Substitute.For<IUser>();
        var addressee = new ProxyAddressee(new AddreseeUser(user), 5);
        addressee.TransferMessage(message);
        user.DidNotReceive().ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void WhenGetMessageLogWrite()
    {
        var message = new Message("233", "12qedqe", 2);
        var user = new User();
        ILogger? logger = Substitute.For<ILogger>();
        var adressee = new ProxyAddressee(new AddresseesLogger(new AddreseeUser(user), logger), 1);
        adressee.TransferMessage(message);
        logger.Received().Log(Arg.Any<Message>());
    }

    [Fact]
    public void SendToMessage_WriteInConsole()
    {
        var message = new Message("233", "12qedqe", 2);
        IMessenger? messenger = Substitute.For<IMessenger>();
        var addressee = new ProxyAddressee(new AdresseeMessenger(messenger), 2);
        addressee.TransferMessage(message);
        messenger.Received().ReceiveMessage(Arg.Any<Message>());
    }
}