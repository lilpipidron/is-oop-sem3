using Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;
using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.MainChain;

public abstract class ParserMainChainBase<TBuilder> : IParserMainChain
{
    protected IParserMainChain? Next { get; private set; }
    protected IParserFlagChain<TBuilder>? FlagChain { get; private set; }
    protected IParserMainChain? AdditionalChain { get; private set; }

    public void AddNext(IParserMainChain parserMainChain)
    {
        if (Next is null)
            Next = parserMainChain;
        else
            Next.AddNext(parserMainChain);
    }

    public void AddFlagChain(IParserFlagChain<TBuilder> parserFlagMainChain)
    {
        if (FlagChain is null)
            FlagChain = parserFlagMainChain;
        else
            FlagChain.AddNext(parserFlagMainChain);
    }

    public void AddAdditionalChain(IParserMainChain additionalMainChain)
    {
        if (AdditionalChain is null)
            AdditionalChain = additionalMainChain;
        else
            AdditionalChain.AddNext(additionalMainChain);
    }

    public abstract MainParseResult? Handle(RequestHandle requestHandle);
}