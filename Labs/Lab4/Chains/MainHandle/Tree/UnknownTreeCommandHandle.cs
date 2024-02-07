using Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainHandle.Tree;

public class UnknownTreeCommandHandle : ParserMainChainBase<int>
{
    public override MainParseResult? Handle(RequestHandle requestHandle)
    {
        return new MainParseResult.Failed($"Unknown tree command {requestHandle.Value.Current()}.\nCheck and try again.\n");
    }
}