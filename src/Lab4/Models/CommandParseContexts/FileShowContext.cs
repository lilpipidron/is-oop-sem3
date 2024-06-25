using Itmo.ObjectOrientedProgramming.Lab4.Commands.Output;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

[GenerateBuilder]
public partial record FileShowContext(
    string Path,
    IOutputMode? OutputMode) : CommandParsedContext;