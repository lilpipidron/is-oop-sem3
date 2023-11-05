using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IMessage
{
    public Message(string title, StringBuilder body, int importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public string Title { get; }
    public StringBuilder Body { get; }
    public int ImportanceLevel { get; }

    public bool Equals(IMessage? other)
    {
        return Title == other?.Title && Body.Equals(other.Body) && ImportanceLevel == other.ImportanceLevel;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Body, ImportanceLevel);
    }
}