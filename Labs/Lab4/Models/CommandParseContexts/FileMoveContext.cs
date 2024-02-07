using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.CommandParseContexts;

[GenerateBuilder]
public partial record FileMoveContext(
    string SourcePath,
    string DestinationPath) : CommandParsedContext;