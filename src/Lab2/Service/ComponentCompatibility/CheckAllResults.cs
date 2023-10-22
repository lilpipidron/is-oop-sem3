using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public static class CheckAllResults
{
    public static Result CheckAllResult(IEnumerable<Result> results)
    {
        Result fullSuccess = new Result.Success(null, new Collection<string>());
        foreach (Result result in results)
        {
            switch (result)
            {
                case Result.Failed:
                    return result;
                case Result.Compatible res:
                    ((Result.Success)fullSuccess).Commentaries.Add(res.Comment);
                    break;
            }
        }

        return fullSuccess;
    }
}