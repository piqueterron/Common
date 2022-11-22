namespace Common.Library.Mediatr;

using Common.Library.Core;
using MediatR;

public static partial class MediatrExtension
{
    public static async Task<Maybe<T>> Link<T>(this Task<Maybe<T>> request, Func<T, Maybe<T>> func)
    {
        var obj = await request;

        return obj.HasValue ? func(obj.Value) : Maybe<T>.None;
    }

    public static async Task<Maybe<TR>> Link<T, TR>(this Task<Maybe<T>> request, Func<T, Maybe<TR>> func)
    {
        var obj = await request;

        return obj.HasValue ? func(obj.Value) : Maybe<TR>.None;
    }
}