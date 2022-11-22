namespace Common.Library.Core;

using System;

public interface IUnitOfWork : IDisposable
{
    Task<Maybe<int>> CommitAsync(CancellationToken cancellationToken = default);
}