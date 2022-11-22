namespace Common.Library.Core;

using System;
using System.Threading.Tasks;

public static partial class MaybeExtension
{
    public static IMaybe<TResult> Or<TResult>(this IMaybe<TResult> maybe, Func<Maybe<TResult>> fallback) =>
        !maybe.HasValue ? fallback() : maybe;

    public static IMaybe<TResult> Or<TResult>(this IMaybe<TResult> maybe, Maybe<TResult> @default) =>
        !maybe.HasValue ? @default : maybe;

    public static async ValueTask<Maybe<TResult>> Or<TResult>(this ValueTask<Maybe<TResult>> maybe, Func<Maybe<TResult>> fallback)
    {
        var obj = await maybe;

        return !obj.HasValue ? fallback() : obj;
    }

    public static async ValueTask<Maybe<TResult>> Or<TResult>(this ValueTask<Maybe<TResult>> maybe, Maybe<TResult> @default)
    {
        var obj = await maybe;

        return !obj.HasValue ? @default : obj.Value;
    }

    public static async Task<Maybe<TResult>> Or<TResult>(this Task<Maybe<TResult>> maybe, Func<Maybe<TResult>> fallback)
    {
        var obj = await maybe;

        return !obj.HasValue ? fallback() : obj;
    }

    public static async Task<Maybe<TResult>> Or<TResult>(this Task<Maybe<TResult>> maybe, Maybe<TResult> @default)
    {
        var obj = await maybe;

        return !obj.HasValue ? @default : obj.Value;
    }
}