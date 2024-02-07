using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Connect.Local;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagArgumentsHandle;

public class LocalConnectMode : ParserFlagChainBase<ConnectContext.Builder>
{
    public override FlagParseResult? Handle(RequestHandle request, ConnectContext.Builder builder)
    {
        if (request.Value.Current().Equals("local", StringComparison.Ordinal) is false)
            return Next?.Handle(request, builder);
        return new FlagParseResult.Success<ConnectContext.Builder>(
            request,
            builder.WithFileSystem(new LocalFileSystem()));
    }
}