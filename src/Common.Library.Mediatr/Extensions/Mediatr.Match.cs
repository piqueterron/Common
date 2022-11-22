namespace Common.Library.Mediatr;

using Common.Library.Core;

public static partial class MediatrExtension
{
    public static async Task<TR> Match<T, TR>(this Task<Maybe<T>> request, Func<T, TR> func, Func<T, TR> error)
    {
        var obj = await request;
        var result = obj.HasValue ? func(obj.Value) : error(obj.Value);

        return result;
    }
}
