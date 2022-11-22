namespace Common.Library.Core;

using System.Threading.Tasks;

public static partial class ResultExtension
{
    public static Maybe<TResult> ToMaybeOrDefault<TResult>(this Result<TResult> result, TResult @default)
    {
        return result.Match(value =>
        {
            if (value is null)
            {
                return @default;
            }

            return value;
        },
        error => @default);
    }

    public static async ValueTask<Maybe<TResult>> ToMaybeOrDefault<TResult>(this ValueTask<Result<TResult>> result, TResult @default)
    {
        var obj = await result;
        return obj.Match(value =>
        {
            if (value is null)
            {
                return @default;
            }

            return value;
        },
        error => @default);
    }

    public static async Task<Maybe<TResult>> ToMaybeOrDefault<TResult>(this Task<Result<TResult>> result, TResult @default)
    {
        var obj = await result;
        return obj.Match(value =>
        {
            if (value is null)
            {
                return @default;
            }

            return value;
        },
        error => @default);
    }
}