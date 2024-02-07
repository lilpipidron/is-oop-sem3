using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IIconVisitor
{
    string Visit(IEnumerable<TreeParts> tree);
}