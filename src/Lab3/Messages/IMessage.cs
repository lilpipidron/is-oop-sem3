using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage : IEquatable<IMessage>
{
    public string Title { get; }
    public StringBuilder Body { get; }
    public int ImportanceLevel { get; }
}