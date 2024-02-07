using Abstractions.Repositories;
using Contracts.Operations;
using Models.BankAccounts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Test
{
    private readonly IBankAccountRepository _bankAccountRepository = Substitute.For<IBankAccountRepository>();
    private readonly BankAccount _testAccount = new BankAccount(666, 666, 6666);

    [Fact]
    public void TryChangeBalance_ShouldDecreaseBalance_WhenEnoughMoney()
    {
        // Arrange
        _bankAccountRepository.GetBalance(Arg.Any<long>()).Returns(6000);
        _bankAccountRepository.TryChangeBalance(Arg.Any<long>(), Arg.Any<decimal>())
            .Returns(new OperationResult.Success());

        // Act
        OperationResult res = _bankAccountRepository.TryChangeBalance(_testAccount.Id, -666);

        // Assert
        Assert.IsType<OperationResult.Success>(res);
        decimal balance = _bankAccountRepository.GetBalance(_testAccount.Id);
        Assert.True(balance == 6000);
    }

    [Fact]
    public void TryChangeBalance_ShouldNotDecreaseBalance_WhenNotEnoughMoney()
    {
        // Arrange
        _bankAccountRepository.TryChangeBalance(_testAccount.Id, Arg.Is<decimal>(x => x < 0))
            .Returns(new OperationResult.NotEnoughMoney());

        // Act
        OperationResult res = _bankAccountRepository.TryChangeBalance(_testAccount.Id, -66666);

        // Assert
        Assert.IsType<OperationResult.NotEnoughMoney>(res);
    }

    [Fact]
    public void Replenishment_ShouldIncreaseBalance()
    {
        // Arrange
        _bankAccountRepository.GetBalance(Arg.Any<long>()).Returns(66666);
        _bankAccountRepository.TryChangeBalance(Arg.Any<long>(), Arg.Any<decimal>())
            .Returns(new OperationResult.Success());

        // Act
        OperationResult res = _bankAccountRepository.TryChangeBalance(_testAccount.Id, 60000);

        // Assert
        Assert.IsType<OperationResult.Success>(res);
        decimal balance = _bankAccountRepository.GetBalance(_testAccount.Id);
        Assert.True(balance == 66666);
    }
}