using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle;

public class ConnectHandle : ParserMainChainBase<ConnectContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("connect", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);

        if (requestHandle.Value.MoveNext() is false)
            return new MainParseResult.Failed("Enough arguments: connect [Address] [-m FileSystemMode].\n");

        string address = requestHandle.Value.Current();
        ConnectContext.Builder connectContextBuilder = new ConnectContext.Builder().WithAddress(address);
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, connectContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<ConnectContext.Builder> resSuccess:
                    connectContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        ConnectContext connectContext;
        try
        {
            connectContext = connectContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Enough arguments: connect [Address] [-m FileSystemMode].\n");
        }

        return new MainParseResult.Success(new Connect(connectContext));
    }
}