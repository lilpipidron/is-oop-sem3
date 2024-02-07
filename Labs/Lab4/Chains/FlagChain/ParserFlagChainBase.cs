using Itmo.ObjectOrientedProgramming.Lab4.Chains.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Chains.FlagChain;

public abstract class ParserFlagChainBase<TBuilder> : IParserFlagChain<TBuilder>
{
    public IParserFlagChain<TBuilder>? Next { get; protected set; }
    public IParserFlagChain<TBuilder>? AdditionalChain { get; protected set; }

    public void AddNext(IParserFlagChain<TBuilder> parserFlagChain)
    {
        if (Next is null)
            Next = parserFlagChain;
        else
            Next.AddNext(parserFlagChain);
    }

    public void AddAdditionalChain(IParserFlagChain<TBuilder> parserFlagChain)
    {
        if (AdditionalChain is null)
            AdditionalChain = parserFlagChain;
        else
            AdditionalChain.AddNext(parserFlagChain);
    }

    public abstract FlagParseResult? Handle(RequestHandle request, TBuilder builder);
}