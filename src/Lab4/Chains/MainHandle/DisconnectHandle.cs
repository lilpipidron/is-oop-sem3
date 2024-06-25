using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle;

public class DisconnectHandle : ParserMainChainBase<DisconnectContext.Builder>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        if (requestHandle.Value.Current().Equals("disconnect", StringComparison.Ordinal) is false)
            return Next?.Handle(requestHandle);
        var disconnectContextBuilder = new DisconnectContext.Builder();
        while (requestHandle.Value.MoveNext() is not false)
        {
            FlagParseResult? res = FlagChain?.Handle(requestHandle, disconnectContextBuilder);
            switch (res)
            {
                case FlagParseResult.Failed resFailed:
                    return new MainParseResult.Failed(resFailed.Reason);
                case FlagParseResult.Success<DisconnectContext.Builder> resSuccess:
                    disconnectContextBuilder = resSuccess.Builder;
                    requestHandle = resSuccess.Request;
                    break;
            }
        }

        DisconnectContext disconnectContext;
        try
        {
            disconnectContext = disconnectContextBuilder.Build();
        }
        catch
        {
            return new MainParseResult.Failed("Enough arguments: disconnect\n");
        }

        return new MainParseResult.Success(new Disconnect(disconnectContext));
    }
}