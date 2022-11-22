namespace Common.Library.Core;

using System.Threading.Tasks;

public static partial class ResultExtension
{
    public static Maybe<TResult> ToMaybe<TResult>(this Result<TResult> result) =>
        result.Match(value => value, error => Maybe<TResult>.None);

    public static async ValueTask<Maybe<TResult>> ToMaybe<TResult>(this ValueTask<Result<TResult>> result)
    {
        var obj = await result;
        return obj.Match(value => value, error => Maybe<TResult>.None);
    }

    public static async Task<Maybe<TResult>> ToMaybe<TResult>(this Task<Result<TResult>> result)
    {
        var obj = await result;
        return obj.Match(value => value, error => Maybe<TResult>.None);
    }
}