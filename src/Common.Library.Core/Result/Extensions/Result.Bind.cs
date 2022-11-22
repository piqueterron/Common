namespace Common.Library.Core;

using System;

public static partial class ResultExtension
{
    public static Result<TResult> Bind<TData, TResult>(this Result<TData> result, Func<TData, Result<TResult>> func) =>
        result.Match(value => func(value), error => error.Value);

    public static Result<TResult> Bind<TResult>(this Result<TResult> result, Func<TResult, Result<TResult>> func) =>
        result.Match(value => func(value), error => error.Value);
}