namespace Common.Library.EFCore;

using Common.Library.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public abstract class RepositoryReadOnly<TContext, TEntity, TKey> : IRepositoryReadOnly<TEntity, TKey>
    where TEntity : notnull, Entity<TKey>
    where TContext : notnull, DbContext
{
    protected readonly TContext Context;

    protected RepositoryReadOnly(TContext context)
    {
        Context = context;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<Maybe<TEntity>> GetByIdAsync(TKey id, CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
}