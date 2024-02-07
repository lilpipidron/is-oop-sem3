using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagArgumentsHandle;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagHandle;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.File;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Local;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    public static IEnumerable<object[]> ConnectCommand_SystemStateChanged_WhenAllParametersIsCorrect()
    {
        yield return new object[]
        {
            new RequestHandle(new CommandIterator("connect /path/to/something -m local")),
            new MainParseResult.Success(new Connect(new ConnectContext("/path/to/something", new LocalFileSystem()))),
        };
    }

    public static IEnumerable<object[]> TreeGoto_FailedCommandExecute_WhenNoPath()
    {
        yield return new object[]
        {
            new RequestHandle(new CommandIterator("tree goto")),
            new MainParseResult.Failed("Not enough arguments: tree goto [Path]\n"),
        };
    }

    public static IEnumerable<object[]> TreeShow_FailedMakeCommand_WhenUnknownCommand()
    {
        yield return new object[]
        {
            new RequestHandle(new CommandIterator("tree show")),
            new MainParseResult.Failed($"Unknown tree command show.\nCheck and try again.\n"),
        };
    }

    [Theory]
    [MemberData(nameof(ConnectCommand_SystemStateChanged_WhenAllParametersIsCorrect))]
    [MemberData(nameof(TreeGoto_FailedCommandExecute_WhenNoPath))]
    [MemberData(nameof(TreeShow_FailedMakeCommand_WhenUnknownCommand))]
    public void Tests(RequestHandle requestHandle, MainParseResult exceptedResult)
    {
        // Arrange
        IParserMainChain parseChain = GetChain();

        // Act
        MainParseResult? res = parseChain.Handle(requestHandle);

        // Assert
        Assert.Equivalent(exceptedResult, res);
    }

    private static IParserMainChain GetChain()
    {
        var flagMConnect = new FlagMConnect();
        flagMConnect.AddNext(new UnknownFlag<ConnectContext.Builder>());
        flagMConnect.AddAdditionalChain(new LocalConnectMode());

        var flagDTreeList = new FlagDTreeList();
        flagDTreeList.AddAdditionalChain(new Depth());
        flagDTreeList.AddNext(new UnknownFlag<TreeListContext.Builder>());

        var flagMFileShow = new FlagMFileShow();
        flagMFileShow.AddNext(new UnknownFlag<FileShowContext.Builder>());
        flagMFileShow.AddAdditionalChain(new OutputModeConsoleFileShow());

        var flagMTreeList = new FlagMTreeList();
        flagMTreeList.AddNext(new UnknownFlag<TreeListContext.Builder>());
        flagMTreeList.AddAdditionalChain(new OutputModeConsoleTreeList());

        var treeList = new TreeListHandle();
        treeList.AddFlagChain(flagMTreeList);

        var fileShow = new FileShowHandle();
        fileShow.AddFlagChain(flagMFileShow);

        var connect = new ConnectHandle();
        connect.AddFlagChain(flagMConnect);

        var fileHandle = new FileHandle();
        fileHandle.AddAdditionalChain(fileShow);
        fileHandle.AddAdditionalChain(new FileCopyHandle());
        fileHandle.AddAdditionalChain(new FileDeleteHandle());
        fileHandle.AddAdditionalChain(new FileMoveHandle());
        fileHandle.AddAdditionalChain(new FileRenameHandle());
        fileHandle.AddAdditionalChain(new UnknownCommandHandle());

        var treeHandle = new TreeHandle();
        treeHandle.AddAdditionalChain(treeList);
        treeHandle.AddAdditionalChain(new TreeGotoHandle());
        treeHandle.AddAdditionalChain(new UnknownTreeCommandHandle());

        connect.AddNext(fileHandle);
        connect.AddNext(treeHandle);
        connect.AddNext(new DisconnectHandle());

        return connect;
    }
}