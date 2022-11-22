namespace Common.Library.Core;

using System;
using System.Threading.Tasks;

public static partial class MaybeExtension
{
    public static IMaybe<TResult> Bind<TData, TResult>(this IMaybe<TData> maybe, Func<TData, Maybe<TResult>> func) =>
        maybe.HasValue ? func(maybe.Value) : Maybe<TResult>.None;

    public static IMaybe<TResult> Bind<TResult>(this IMaybe<TResult> maybe, Func<TResult, Maybe<TResult>> func) =>
        maybe.HasValue ? func(maybe.Value) : Maybe<TResult>.None;

    public static async ValueTask<Maybe<TResult>> Bind<TData, TResult>(this ValueTask<Maybe<TData>> maybe, Func<TData, Maybe<TResult>> func)
    {
        var obj = await maybe;

        return obj.HasValue ? func(obj.Value) : Maybe<TResult>.None;
    }

    public static async ValueTask<Maybe<TResult>> Bind<TResult>(this ValueTask<Maybe<TResult>> maybe, Func<TResult, Maybe<TResult>> func)
    {
        var obj = await maybe;

        return obj.HasValue ? func(obj.Value) : Maybe<TResult>.None;
    }

    public static async Task<Maybe<TResult>> Bind<TData, TResult>(this Task<Maybe<TData>> maybe, Func<TData, Maybe<TResult>> func)
    {
        var obj = await maybe;

        return obj.HasValue ? func(obj.Value) : Maybe<TResult>.None;
    }

    public static async Task<Maybe<TResult>> Bind<TResult>(this Task<Maybe<TResult>> maybe, Func<TResult, Maybe<TResult>> func)
    {
        var obj = await maybe;

        return obj.HasValue ? func(obj.Value) : Maybe<TResult>.None;
    }
}