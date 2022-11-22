namespace Common.Library.Core;

public static partial class ResultExtension
{
    public static void Match<TValue>(this Result<TValue> result, Action<TValue> onValue, Action<Error?> onError = default)
    {
        if (!result.IsError)
        {
            onValue(result.Value);
        }
        else
        {
            onError?.Invoke(result.Error);
        }
    }

    public static TResult Match<TValue, TResult>(this Result<TValue> result, Func<TValue, TResult> onValue, Func<Error?, TResult> onError = default)
    {
        if (!result.IsError)
        {
            return onValue(result.Value);
        }

        return onError(result.Error);
    }
}
