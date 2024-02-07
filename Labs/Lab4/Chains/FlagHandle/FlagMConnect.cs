using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagHandle;

public class FlagMConnect : ParserFlagChainBase<ConnectContext.Builder>
{
    public override FlagParseResult? Handle(RequestHandle request, ConnectContext.Builder builder)
    {
        if (request.Value.Current().Equals("-m", StringComparison.Ordinal) is false)
            return Next?.Handle(request, builder);
        return request.Value.MoveNext() is false ?
            new FlagParseResult.Failed($"Not enough arguments: -m 'file system mode'\n")
            : AdditionalChain?.Handle(request, builder);
    }
}