namespace Common.Library.Core;

public interface IRepositoryReadOnly<TEntity, TKey>
    where TEntity : notnull, Entity<TKey>
{
    Task<Maybe<TEntity>> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
}