namespace Common.Library.Core;

using System;

public static partial class MaybeExtension
{
    public static Result<TResult> ToResult<TResult>(this Maybe<TResult> maybe) =>
        maybe.HasValue ? maybe.Value : Error.Create("Maybe has not value to convert.", new ArgumentNullException());

    public static Result<TResult> ToResult<TResult>(this Maybe<TResult> maybe, Error error) =>
        maybe.HasValue ? maybe.Value : error;

    public static async ValueTask<Result<TResult>> ToResult<TResult>(this ValueTask<Maybe<TResult>> maybe)
    {
        var obj = await maybe;
        return obj.HasValue ? obj.Value : Error.Create("Maybe has not value to convert.", new ArgumentNullException());
    }

    public static async ValueTask<Result<TResult>> ToResult<TResult>(this ValueTask<Maybe<TResult>> maybe, Error error)
    {
        var obj = await maybe;
        return obj.HasValue ? obj.Value : error;
    }

    public static async Task<Result<TResult>> ToResult<TResult>(this Task<Maybe<TResult>> maybe)
    {
        var obj = await maybe;
        return obj.HasValue ? obj.Value : Error.Create("Maybe has not value to convert.", new ArgumentNullException());
    }

    public static async Task<Result<TResult>> ToResult<TResult>(this Task<Maybe<TResult>> maybe, Error error)
    {
        var obj = await maybe;
        return obj.HasValue ? obj.Value : error;
    }
}