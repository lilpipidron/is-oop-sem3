using System;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagArgumentsHandle;

public class OutputModeConsoleTreeList : ParserFlagChainBase<TreeListContext.Builder>
{
    public override FlagParseResult? Handle(RequestHandle request, TreeListContext.Builder builder)
    {
        if (request.Value.Current().Equals("console", StringComparison.Ordinal) is false)
            return Next?.Handle(request, builder);
        return new FlagParseResult.Success<TreeListContext.Builder>(
            request,
            builder.WithOutputMode(new ConsoleOutput()));
    }
}